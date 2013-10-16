//var data = [
//	["父级ID","当前ID","值","层次路径"]
//	["0","1","Danny","0"],
//	["1","2","Danny2","1_2"],
//];
//

//option:
//{
//  source :[ {name,data,level}, {...} , {...} ]  // :name -> Select控件名称 data -> 绑定数据 ,level -> 层次,从0开始
//  prepareData : [ {parentID:父级ID, data:对应父级ID的子级数据} ] //该属性总是优先于source[0].data
//  doCache : false //是否在实例化时执行预缓冲数据,初始化时会自动遍历所有父级ID调用 getChildData 方法,初始缓冲数据(间接调用setCacheData)
//}

//source[0].data = [ ["父级ID","当前ID","值","层次路径"]  , [...] , ... ]
//层次路径即从父级ID 到当前ID 的路径  如广东省ID为1,广州市ID为2,则路径值为 1_2
function SyncSelector(source,op)
{
	this.option = {
	   defaultTexts : ['请选择'],
	   defaultValues :[-1]
	}
	jQuery.extend( this.option , op || {} );
	this.source = source;
	
	this.init = function()
	{
		this.id = this.format( 'selector_{0}' , (++SyncSelector.instanceCount) )  ;//当前实例标识号
		this.cacheData = [];//缓存数据,每次触发选择时就会缓冲,用于每次根据父级ID查询数据列表的缓冲 [parendID,data] //data ->  ["父级ID","当前ID","值","层次路径"]
		this.selectorList = [];//选择控件集合
		//根据level排序 source
		this.source.sort(
				function(o1,o2)
				{
					var level01 = parseInt( o1.level );
					var level02 = parseInt( o2.level );
					return (level01 > level02) ?  1 : -1;
				}
		);
		
		//设置option.defaultTexts,option.Values数组长度与source长度一致
		if(this.source.length > this.option.defaultTexts.length)
		{
			var defaultText = this.option.defaultTexts[0];
			this.option.defaultTexts = [];
			for(var i=0;i<this.source.length;i++)
				this.option.defaultTexts.push(defaultText);
		}
		
		if(this.source.length > this.option.defaultValues.length)
		{
			var defaultValue = this.option.defaultValues[0];
			this.option.defaultValues = [];
			for(var i=0;i<this.source.length;i++)
				this.option.defaultValues.push(defaultValue);
		}
		
	}
	
	//设置数据源
	//data:
	//[  
	//     ["父级ID","当前ID","值","层次路径"],
	//     ["父级ID","当前ID","值","层次路径"]
	//]
	//ontrolName:控件名称
	//level:层次
	this.setDataSource = function(aryData,controlName,level)
	{
		if(aryData==null || !(aryData instanceof Array) ) return null;
		var newGroup = this.getDataSource( controlName );
		if(newGroup == null){
		   newGroup = { name : controlName, data:[] , level:-1};
		}
		newGroup.data = aryData;
		newGroup.level = level;
		this.source.push(newGroup);
		return newGroup;
	};
	
	//获取控件数据源
	this.getDataSource = function(controlName)
	{
			for(var i=0;i<this.source.length;i++)
			{
				if( this.source[i].name == controlName )
					return this.source[i];
			}
			return null;
			
	};
	
	//根据父级ID获取子级对应数据列表
	this.getChildData = function(parentID,controlName)
	{
		//从缓冲数据里查找
		var dataList = this.getCacheData(parentID,controlName);
		if(dataList!=null) 
			return dataList;
			
		
		//重新查找数据
		var group = null;
		for(var i=0;i<this.source.length;i++)
		{
			if(this.source[i].name == controlName)
				group = this.source[i];
		}
		
		//alert(parentID + " " + childLevel + " " + (group == null) );
		
		
		if( group==null || group.data==null )
			return null;
			
		var data = group.data;
		
		//缓冲数据
		var foundData = [];
		for(var i=0;i<data.length;i++)
		{
			if(data[i][0] == parentID)
				foundData.push(data[i]);
		}
		
		this.setCacheData(parentID,controlName,foundData)
		return foundData;
	}
	
	
	
	//设置缓冲数据
	this.setCacheData = function(groupID,controlName,data)
	{
		var cacheDataList = this.getCacheData(groupID,controlName);
		if(cacheDataList==null)
			this.cacheData.push( {groupID:groupID , data:data , controlName:controlName } );
		else
			cacheDataList.data = data;
	}
	
	//获取在缓存数据对应groupID 的数据列表
	//成功返回Array,失败返回null
	this.getCacheData = function(groupID,controlName)
	{
		for(var i=0;i<this.cacheData.length;i++)
		{
			if(this.cacheData[i].groupID == groupID && this.cacheData[i].controlName == controlName) 
				return this.cacheData[i].data;
		}
		return null;
	}
	
	this.control = function(name)
	{
		
		if(name==null)//获取所有控件集合
		{
			//按Level排序
			this.selectorList.sort(
				function(o1,o2)
				{
					var level01 = parseInt( o1.attr('level') );
					var level02 = parseInt( o2.attr('level') );
					return (level01 > level02) ?  1 : -1;
				}
			)
			
			return this.selectorList;
		}
		
		
		for(var i=0;i<this.selectorList.length;i++)
		{
			if(this.selectorList[i].attr('name')==name)
				return this.selectorList[i];
		}
		return jQuery(  this.format( 'select[@id^={0}][@name={1}]' , this.id , name ) );
	}
	
	//container : 容器,opControlName:已有控件名称(可选)
	//设定opControlName 成功返回选择器,失败返回nul
	//没有设定opControlName 返回选择器集合
	this.render = function(container,opControlName)
	{
		var box = jQuery(container);
		if( opControlName!=null )//渲染单个控件
		{
			var jqControl = this.control(opControlName);
			if(jqControl.width()!=null)
			{
				jqControl.insertAfter(container);
				return jqControl;
			}
			else
			{
				var bindData = this.getDataSource(opControlName);
				if ( bindData==null ){
					alert("没有找到 " + opControlName + " 的数据");
					return null;
				}
				var controlID = this.format("{0}_controls_{1}", this.id , bindData.name );
				var selector = this._renderToSelector_( controlID , bindData.name , bindData.data, bindData.level );
				box.append( selector );
				this.selectorList.push( selector );
				return selector;
			}
		}
		else //渲染所有控件
		{
			var ret =[];
			
              for(var i=0;i<this.source.length;i++){
				var bindData = this.source[i];
				var controlID = this.format("{0}_controls_{1}", this.id , bindData.name );
				
				var selector = null;
				//只渲染第一选择器
				if (i==0){
					selector = this._renderToSelector_( controlID , bindData.name , bindData.data, bindData.level )
				}
				else //其他下级选择器渲染,并且设默认值
				{
					var defaultData = [ [-1, this.option.defaultValues[i], this.option.defaultTexts[i],"-1"] ];						
					selector = this._renderToSelector_( controlID , bindData.name , defaultData , bindData.level )
				}
				
				ret.push( selector );
				box.append( selector );
				this.selectorList.push( selector );
				}
				
			return ret;
		}
		
	};
	
	
	
	
	//返回jq 对象
	this._renderToSelector_ = function(id,name,ary,level)
	{
		var retObj = jQuery( this.format("<select id='{0}' name='{1}' level='{2}'></select>",id,name,level) );
		var s = [];
		
		if(level==0)//第一个选择器添加默认选项
		{
			s.push( this.format("<option value='{0}' levelPath='-1'>{1}</option>" , this.option.defaultValues[0] , this.option.defaultTexts[0] ) );
		}
		
		for(var i=0;i<ary.length;i++){
			s.push( this.format("<option value='{0}' levelPath='{1}'>{2}</option>" , ary[i][1], ary[i][3] , ary[i][2] ) );
		}
		retObj.html(s.join("\r\n"));
		var instance = this;
		retObj.bind( 
					'change' , 
					function()
					{
						 //alert('change');
						 var selector = jQuery(this);
						 var curID = selector.val(); //当前选择的值,下一个子级控件的父级ID
						 var level = parseInt( selector.attr("level") ); //当前控件层次
						
						 
						 var nextLevel = level+1; //下一个控件层次
						
						 var nextSelector = jQuery( instance.format( "select[@level='{0}'][@id^='{1}']" , nextLevel , instance.id ) ); //下一个子级控件
						 
						 var data = instance.getChildData( curID , nextSelector.attr('name') );//子级控件绑定的数据
						 if(data!=null && data.length>0 && nextSelector.width()!=null )
						 {		
							instance._bindData_( nextSelector , data , nextLevel );
						 }
						 else
						 {
							 //没有找到数据则清空
							 nextSelector.html(
								instance.format("<option value='{0}' parentID='-1'>{1}</option>" , instance.option.defaultValues[nextLevel] , instance.option.defaultTexts[nextLevel] )
							 );
						 }
						 //触发nextSelector change事件
						 nextSelector.trigger('change');
						 
					}
		);
		return retObj;
	};
	
	//s 控件或控件名称
	//绑定的数据
	this._bindData_ = function(s,data,level)
	{
		var selector = typeof (controlName) == "string" ? this.control( controlName ) : s;
		var html = [];
		html.push( this.format("<option value='{0}' parentID='-1'>{1}</option>" , this.option.defaultValues[level] , this.option.defaultTexts[level] ) );
		for(var i=0;i<data.length;i++)
			html.push( this.format("<option value='{0}' parentID='{1}'>{2}</option>" , data[i][1], data[i][0] , data[i][2] ) );
		selector.html(html.join("\r\n") );
	}
	
	//字符串格式化
	this.format = function(str)
	{
		if(arguments.length>1){
			
			for(var i=1;i<arguments.length;i++){
				str=str.replace( eval( '/\\{'+ (i-1) + '\\}/gi' ) , arguments[i] );
			}
		}
		return str;
	};
	
	this.select = function(controlName,id,preventEvent)
	{
		
		var selector = null;
		if( (typeof controlName)=="string")
			selector = this.control(controlName);
		else
			selector = this.control()[controlName];
			
		
		if(selector == null || selector.width()==null)return;
		if(!preventEvent){
		    selector.val(id).trigger('change');
		}
	}
	
	//获取当前SyncSelector所有Selector 值的集合 返回对应Name 集合的hash 引用: var val = syncSelector.values();alert(val.province);
	this.values = function()
	{
		var v = {};
		for(var i=0;i<this.selectorList.length;i++){
			var s = this.selectorList[i].attr('name');
			v[s] = this.selectorList[i].val();
		}
		return v;
	}
	
	//设置或获取最后一个值
	this.value = function(value)
	{
		var lastSelector = null;
		var lastSource = null;
		
		for(var i=this.source.length-1;i>=0;i--)//获取最后一个有效数据源和选择的值
		{
			var o = this.control( this.source[i].name );
			if(o.width()!=null){//最后一个被渲染的控件存在
				lastSelector = o;
				lastSource = this.source[i];
				break;
			}
		}
		
		if(value==null)//获取当前选择的值
			return lastSelector == null ? null : lastSelector.val();
		
		
		//设置值
		
		if (lastSelector == null ) return;
		
		var levelPath = null;//最后一个值的层次级别
		for(var i=0;i<lastSource.data.length;i++){
			var data = lastSource.data[i];
			if (data[1] == value)
				levelPath = data[3];
		}
		
		if(levelPath==null) //没有找到相应数据
		   return;
		
		
		
		//获取最后一选择的值的层次路径,以选择父级对应的值
		var values = levelPath.split('_');
		if(values.length==0) return;
		
		//提示:第一个控件已绑定所有数据
		for(var i=0;i<values.length;i++ )
		{
			for(var j=0;j<this.source.length;j++){
				if (this.source[j].level == i)
					this.select(this.source[j].name,values[i]);
			}
		}
		
	}
	
	this.init();
	
}

SyncSelector.instanceCount = 0;
