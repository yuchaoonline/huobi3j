/*
Iterator ���������,֧��ÿ��һ�������¼�����,���������ݵ�����
Author:Issac
email:talent-chow@live.cn

�¼� : onMoved(e)
e = {
		array:��ǰ��������,
		index:��ǰ�α�������,
		cancel:��ǰ�ƶ��α��Ƿ��ѱ���ֹ,�����жϵ�ǰ�����Ƿ���Ч
	}

�������� : moveNext,movePrev,moveLast,moveFirst
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
	
	this.moveNext = function(){ //����BOF
		return this.move(this._curIndex+1);
	};
	
	this.movePrev = function(){ //����EOF
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
