/*
Iterator 数组迭代器,支持每次一迭代的事件触发,可用于数据的驱动
Author:Issac
email:talent-chow@live.cn

事件 : onMoved(e)
e = {
		array:当前迭代数组,
		index:当前游标索引号,
		cancel:当前移动游标是否已被终止,用于判断当前迭代是否有效
	}

迭代方法 : moveNext,movePrev,moveLast,moveFirst
**/

function Iterator(array)
{
    this._ary = array;
	this._curIndex = 0;
	this._onMoveEvent = null; 
	
	this._rasieMoveEvent = function(e){
		if(this._onMoveEvent)
			this._onMoveEvent(e);
	}
	
	this.bindEvent = function(fn){
		this._onMoveEvent = fn;
	};
	
	this.moveNext = function(){ //返回BOF
		return this.move(this._curIndex+1);
	};
	
	this.movePrev = function(){ //返回EOF
		return this.move(this._curIndex-1);
	};
	
	this.moveLast = function(){
		this.move( this._ary.length-1 );
	};
	
	this.moveFirst = function(){
		this.move(0);
	};
	
	this.move = function(index){
		var cancel = (index <0 || index >=this._ary.length);
		if(!cancel) this._curIndex = index;
		this._rasieMoveEvent({ cancel:cancel,array:this._ary,index:this._curIndex});
		return cancel;
	};
	
	this.getArray = function(){
		return this._ary;
	}
	
	this.append = function(item){
		this._ary.push( item );
		return this._ary.length-1;
	}
}
