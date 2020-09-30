//function myLogin() {
//	//debugger;
//	var validate = new Object();
//	validate.Email = $('#email').val();
//	validate.Password = $('#password').val();
//	$.ajax({
//		type: 'POST',
//        url: "/validate/",
//		cache: false,
//		dataType: "JSON",
//		data: validate
//    }).then((result) => {
//		if (result.status == true) {
//			window.location.href = "/main";
//		} else {
//			toastr.warning(result.msg)
//		}
//	})
//};
function myLogin() {
    //debugger;
    Swal.showLoading()
    //var check = validate();
    //if (check == false) {
    //    Swal.fire('Error', 'Invalid Data', 'error');
    //    return false;
    //}
    var loginVM = {
        Email: $('#email').val(),
        Password: $('#password').val()
    };
    $.ajax({
        url: "/login-validate",
        data: loginVM,
        cache: false,
        type: "POST",
        dataType: "JSON"
    }).then((result) => {
        if (result.Item1.StatusCode == 200) {
            if (result.item3 === "false") {
                window.location.href = "/verifies";
            } else {
                window.location.href = "/profile";
            }
        } else {
            Swal.fire('Error', result.Item2, 'error');
        }
    });
}