//检测是否已至少选中一个checkbox
function checkSelect(name){
 chkBoxs = document.getElementsByName(name);
 for(var i=0;i<chkBoxs.length;i++)
          if(chkBoxs[i].checked)return true;
 alert("请选择要操作的项!");
 return false;
}

//统一设置checkBox
function setCheckGroup(checkBoxGroupName,isCheck){
 chkBoxs = document.getElementsByName(checkBoxGroupName);
    for(var i=0;i<chkBoxs.length;i++)
          chkBoxs[i].checked=isCheck;
return false;
}
 

//反选checkBox
function resverSelect(checkBoxGroupName){
 chkBoxs = document.getElementsByName(checkBoxGroupName);
    for(var i=0;i<chkBoxs.length;i++)
          chkBoxs[i].checked= !   chkBoxs[i].checked;
 return false;
}