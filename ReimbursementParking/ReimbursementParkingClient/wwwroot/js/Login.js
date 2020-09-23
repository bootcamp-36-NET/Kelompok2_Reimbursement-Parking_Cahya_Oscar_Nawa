function myLogin() {
	//debugger;
	var validate = new Object();
	validate.Email = $('#email').val();
	validate.Password = $('#password').val();
	$.ajax({
		type: 'POST',
        url: "/validate/",
		cache: false,
		dataType: "JSON",
		data: validate
    }).then((result) => {
		if (result.status == true) {
			debugger;
			window.location.href = "/main";
		} else {
			toastr.warning(result.msg)
		}
	})
};