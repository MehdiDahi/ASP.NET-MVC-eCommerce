function ShowImagePreview(imageUploader, previewImage) {
    if (imageUploader.files && imageUploader.files[0])
    {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImage).attr('src',e.target.result);
        }
        reader.readAsDataURL(imageUploader.files[0]);
    }
}

function jQueryAjaxPost(form) {
    $.validator.unobtrusive.parse(form);
    if($(form).valid())
    {
        var ajaxConfig = {
            type: 'POST',
            url: form.action,
            data: new formData(form),
            contentType: false,
            processData: false,
            success: function (response) {

            }

        }
        if ($(form).attr('enctype') == "multipart/form-data")
        {
            ajaxConfig["contentType"] = false;
            ajaxConfig["processData"] = false;
        }

        $.ajax(ajaxConfig);
    }
    return false;
}

function Edit(url) {

    $.ajax({
        type: 'GET',
        url: url,
        success: function (response) {
            
            $("#myform").html(response);
            $("#mynavbar").hide();
            document.getElementById("liItem").innerHTML = "Edit Product";
            document.getElementById("cardItem").innerHTML = "Edit Product";
            document.getElementById("saveInput").value = "Save";
        }

    });
}

function Add(url) {

    $.ajax({
        type: 'GET',
        url: url,
        success: function (response) {

            $("#myform").html(response);
            $("#mynavbar").hide();
        }

    });
}

//function inputKey() {

//    $("#qte").keypress(function (e) {
//        if(e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57))
//        {
//            alert("Enter Numbers Only in Qte Field!");
//            //$("#errormsg").html("Enter Numbers Only in Qte Field!").show().fadeOut("slow");
//            return false;
//        }
//    });
//}