﻿

$(document).ready(function () {
    
});

function GetProfile() {
    //debugger;
    $.ajax({
        url: "/GetProfile/",
        type: "GET",
        dataType: "json",
    }).then((result) => {
        //debugger;
        $('#Id').val(result.Id);
        $('#NIK').val(result.NIK);
        $('#Email').val(result.Email);
        $('#Name').val(result.Name);
        $('#Site').val(result.Site);
        $('#Phone').val(result.Phone);
        $('#Address').val(result.Address);
        $('#RoleOption').val(result.RoleID);
        $('#update').show();
        $('#myModal').modal('show');
    })
}

function Update() {
    //debugger;
    var Data = new Object();
    Data.Id = $('#Id').val();
    Data.NIK = $('#NIK').val();
    Data.Email = $('#Email').val();
    if ($('#Pass').val() != "") {
        Data.Password = $('#Pass').val();
    }
    Data.Name = $('#Name').val();
    Data.Site = $('#Site').val();
    Data.Phone = $('#Phone').val();
    Data.Address = $('#Address').val();
    Data.roleID = $('#RoleOption').val();
    $.ajax({
        type: 'POST',
        url: "/updProfile/",
        cache: false,
        dataType: "JSON",
        data: Data
    }).then((result) => {
        //debugger;
        if (result.statusCode == 200) {
            $.notify({
                // options
                icon: 'flaticon-alarm-1',
                title: 'Notification',
                message: 'Updated Successfully',
            }, {
                // settings
                element: 'body',
                type: "success",
                allow_dismiss: true,
                placement: {
                    from: "top",
                    align: "center"
                },
                timer: 1500,
                delay: 5000,
                animate: {
                    enter: 'animated fadeInDown',
                    exit: 'animated fadeOutUp'
                },
            });
            window.setTimeout(function () {
                location.reload();
            }, 2000);
        } else {
            $.notify({
                // options
                icon: 'flaticon-alarm-1',
                title: 'Notification',
                message: 'Failed to Input',
            }, {
                // settings
                element: 'body',
                type: "danger",
                allow_dismiss: true,
                placement: {
                    from: "top",
                    align: "center"
                },
                timer: 1500,
                delay: 5000,
                animate: {
                    enter: 'animated fadeInDown',
                    exit: 'animated fadeOutUp'
                },
            });
            window.setTimeout(function () {
                location.reload();
            }, 2000);
        }
    })
}