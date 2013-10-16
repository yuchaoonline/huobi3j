function multEdit(id) {
    KE.show({
        id: id,
        imageUploadJson: '/kindeditor/upload_json.ashx',
        fileManagerJson: '/kindeditor/file_manager_json.ashx',
        resizeMode: 1,
        allowPreviewEmoticons: true,
        allowUpload: true,
        items: ['fontname', 'fontsize', '|', 'textcolor', 'bgcolor', 'bold', 'italic', 'underline', 'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist', 'insertunorderedlist', '|', 'emoticons', 'image', 'link']
    });
}