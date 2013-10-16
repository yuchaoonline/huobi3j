var keywords = {
	search : function(keyword,shower)
	{
		if(!keyword || keyword.length==0){
			alert('关键字不能为空!');
			return;
		}
		
		$.ajaxSetup({
			 error : function(XMLHttpRequest, textStatus, errorThrown)
			 {
				 alert(textStatus);
			 }
		});
		$.post('Keywords.ashx',{ k:encodeURI(keyword) },
			function(data)
			{
				$(shower).html(data);
			}  
		);
	}
};