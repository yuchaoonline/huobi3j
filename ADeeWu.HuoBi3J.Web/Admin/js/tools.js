
/**
 * js 去除空格
 */
String.prototype.trim = function() 
{ 
	return this.replace(/(^\s*)|(\s*$)/g,""); 
}


/**
 * 日期格式验证
 */
checkDate = function(theDate){
  var reg = /^\d{4}-((0{0,1}[1-9]{1})|(1[0-2]{1}))-((0{0,1}[1-9]{1})|([1-2]{1}[0-9]{1})|(3[0-1]{1}))$/;  
  var result=true;
  if(!reg.test(theDate))
    result = false;
  else{
    var arr_hd=theDate.split("-");
    var dateTmp;
    dateTmp= new Date(arr_hd[0],parseFloat(arr_hd[1])-1,parseFloat(arr_hd[2]));
    if(dateTmp.getFullYear()!=parseFloat(arr_hd[0])
       || dateTmp.getMonth()!=parseFloat(arr_hd[1]) -1 
        || dateTmp.getDate()!=parseFloat(arr_hd[2])){
        result = false
    }
  }
  return result;
}

/**
 * 格式化日期,得到日期部分的值
 */
 function getDatePart(date) {
 	var parts = date.split(" ");
	var dpart = ""
	if(parts.length > 0) {
		dpart = parts[0]
	}else{
		// 一个不符合标准日期的字符串 (使用传递进来的值)
		dpart = date
	}
	
	return dpart;
	
 }
 
 
 /**
  * 加入收藏
  */
 function addBookmark(title,url) {
	if (window.sidebar) { 
	window.sidebar.addPanel(title, window.location.href,""); 
	} else if( document.all ) {
	window.external.AddFavorite( window.location.href, title);
	} else if( window.opera && window.print ) {
	return true;
	}
}