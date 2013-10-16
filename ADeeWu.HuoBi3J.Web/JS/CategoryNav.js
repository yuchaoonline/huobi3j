$(document).ready(function(){
	
	//ie 测试
	list = [];
	var response = function(data){
		list.push(data);
		//$('#Result').html( list.join('<br />') );
	};


    //绑定每个一级分类鼠标经过事件
	$('.CategoryNav li').each(function(index){
		var target = $(this),
			dataName = target.attr('data'),
			data = $('#' + dataName);
		target.hover(
			function(){
				if(document.cateNavData!=null){
					document.cateNavData.removeClass('categoryNav-data-hover');
				}
				
				document.cateNavData = data.removeClass('categoryNav-data-hover').addClass('categoryNav-data-hover');
				//检测是否已计划移除当前 categoryNav-data 鼠标经过样式 categoryNav-data-hover
				
				//var handler = data.data('delay');
				//console.log('clearTimeout : ' + handler);
				//clearTimeout(handler);
				return false;
			},
			function(){
				//data.removeClass('categoryNav-data-hover');
				//data.children('.categoryNav-lv03').removeClass('categoryNav-lv03-hover');
				return false;
			}
		);
	});
	
	//绑定属于一级分类下的所有分类鼠标事件
	$('.categoryNav-data').each(function(){
		var dataBox = $(this),
		    h2 = dataBox.find('h2'),
			lv03DataBox = h2.next(),
			h3 = dataBox.find('.c3'),
			h4 = dataBox.find('.c4');
			
		h2.hover(
			function(){
				var target = $(this),
					next = target.next(),
					lastH2 = dataBox.data('curH2'),
					last = dataBox.data('curLevel02');
				//console.log('h2 hover');
				if( last!=null && last != next ){
					last.removeClass('categoryNav-lv03-hover');
					lastH2.removeClass('h2-hover');
				}
				next.addClass('categoryNav-lv03-hover');
				target.addClass('h2-hover');
				dataBox.data('curLevel02',next);
				dataBox.data('curH2',target);
				//alert( next == null );
				
				if(window.onCategoryNavHover){
					window.onCategoryNavHover();
				}
				return false;
			},
			function(){
				//$(this).next().removeClass('categoryNav-lv03-hover');
				return false;
			}
		)
		
		lv03DataBox.hover( 
			function(){
				return false;
			}
			,
			function(){ //.categoryNav-lv03 鼠标离开
				var target = $(this),
					child = target.children('.categoryNav-lv04'),
					parent = target.parent();
					
				target.removeClass('categoryNav-lv03-hover'); //移除当前鼠标经过样式
				child.removeClass('categoryNav-lv04-hover'); //移除所有子级鼠标经过样式
				//鼠标从3级分类移出时执行定时隐藏二级分类容器
				var handler = isc.util.delay(function(){
					this.removeClass('categoryNav-data-hover');
					if(window.onCategoryNavMouseOut){
						window.onCategoryNavMouseOut();
					}
				},500,dataBox,null);
				dataBox.parent().data('delay',handler);
				return false;
			}
		).bind('mousemove',function(){
			return false;
		});
		
		h3.hover(
			function(){
				$(this).next().removeClass('categoryNav-lv04-hover').addClass('categoryNav-lv04-hover');
				return false;
			},
			function(){
				//$(this).next().removeClass('categoryNav-lv04-hover');
				return false;
			}
		).next().hover(
			function(){ return false; }
			,
			function(){ //.categoryNav-lv04 鼠标离开
				$(this).removeClass('categoryNav-lv04-hover').children('.categoryNav-lv05').removeClass('categoryNav-lv05-hover');
				return false;
			}
		);
		
		h4.hover(
			function(){
				var target = $(this),
					lv04_id = target.attr('cid'),
					next = target.next(),
					nextLoaded = !!next.attr('load'),
					parent = target.parent();
				
				var fn = function(){
					if(document.categoryNavLv05!=null){
						document.categoryNavLv05.removeClass('categoryNav-lv05-hover');
					}
				
					//显示五级分类
					document.categoryNavLv05 = next.addClass('categoryNav-lv05-hover');
				};
				if(nextLoaded){
					
					fn();
					
				}else{ //加载五级分类数据
					
					$.get('/shop/CateLv05.ashx',
						  { cid:lv04_id },
						   function(data){
							   //加载成功:设置加载标志值
							   next.attr('load',true);
							   next.html(data);
							   fn();
						   }
					);
					
				}
				
				return false;
			},
			function(){
				//$(this).next().removeClass('categoryNav-lv05-hover');
				return false;
			}
		).next().hover(
			function(){ return false; },
			function(){ //.categoryNav-lv05 鼠标离开
				$(this).removeClass('categoryNav-lv05-hover');
				return false;
			}
		);
		
		
	}).hover( //$('.categoryNav-data').each(function(){
		function(){
			return false;
		},
		function(){
			if(window.onCategoryNavMouseOut){
				window.onCategoryNavMouseOut();
			}
				
			response('mouseout');
			$(this).removeClass('categoryNav-data-hover');
			return false;
		}
	).bind('mousemove',function(){
		response('mouse move');
		//console.log('mousemove');
			var target = $(this),
			    handler = target.parent().data('delay');
			if(handler!=null){
				response('clearTimeout');
				clearTimeout(handler);
				target.parent().data('delay',null);
			}
			return false;
	});
	
	
	//搜索
	$('#btnProSearch').click(function(){
		var key = $.trim( $('#txtProKey').val() );
		if(key.length==0){
			alert('请输入关键字!');
		}else{
			location.href = '/Shop/Products/?key=' + encodeURI( key );
		}
		return false;
	});
	
});//$(document)
