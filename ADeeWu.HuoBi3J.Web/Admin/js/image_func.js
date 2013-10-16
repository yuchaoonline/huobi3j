//作者:Issac
//QQ:86508962


//自动调整图片大小，超过限制则自动按比例缩小。
//例子：
// <img src="demo.jpg" width="0" height="0" onload="imgAutoSize(this,50,50)" onerror="this.src='nopic.gif'" style='display:none;' /> 
// <img src="demo.jpg" width="0" height="0" onload="imgAutoSize(this,50,50,'block')" onerror="this.src='nopic.gif'" style='display:none;' /> 自定义display 方式
function imgAutoSize(elemImg, MaxWidth, MaxHeight,display)
{
    var img = new Image();
	img.src = elemImg.src;
	var w = MaxWidth;
	var h = MaxHeight;
	var w2 = img.width;
	var h2 =  img.height;
	var scale = w2 / h2;
	if(w2 < w && h2 < h){
		elemImg.style.display = 'inline';
		return;
	}
	if(w2 >= w){
		w2 = w;
		h2 = w2 / scale;
	}
	if(h2 >= h){
		h2 = h;
		w2 = h2 * scale;
	}
	
	elemImg.style.display = display ? display : 'inline';
	elemImg.width = Math.round(w2);
	elemImg.height = Math.round(h2);
}
