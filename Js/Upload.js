

//$(document).ready(function () {
//    $('#btnUploadFile').on('click', function () {
//        var data = new FormData()
//        var files = $("#fileUpload").get(0).files;
//        // Add the uploaded image content to the form data collection
//        if (files.length > 0) {
//            data.append("UploadedImage", files[0]);
//        }
//        // Make Ajax request with the contentType = false, and procesDate = false
//        var ajaxRequest = $.ajax({
//            type: "POST",
//            url: "http://localhost:16158/api/FileUploads",
//            contentType: false,
//            processData: false,
//            data: data
//        });
//        ajaxRequest.done(function (xhr, textStatus) { });
//    });
//});


var formData = new FormData(document.getElementById('formUploadAvatar'));

that.LblBtnUploadImage('Chargement en cours...');
that.ClassBtnUpload("loading");

var data = new FormData();

var files = jQuery("#avatar").get(0).files;

if (files.length > 0) {
    data.append("avatar", files[0]);
}

var ajaxRequest = jQuery.ajax({
    type: "POST",
    url: window.ProfilageApiUrl + "avatar/upload-avatar?access_token=" + rcOAuth2Client.getAccessToken(),
    contentType: false,
    processData: false,
    data: data,
    success: function (data) {
        that.Avatar(data);
        that.NewAvatar = data;
        that.LblBtnUploadImage('Choisir une nouvelle photo');
        that.ClassBtnUpload("cbcrc-icon-edit");
    },
    error: function (data) {
        that.AvatarErrorMessage('Erreur lors du téléchargement de la photo. Veuillez réessayer.');
        that.LblBtnUploadImage('Choisir une nouvelle photo');
        that.ClassBtnUpload("cbcrc-icon-edit");
    }
});
