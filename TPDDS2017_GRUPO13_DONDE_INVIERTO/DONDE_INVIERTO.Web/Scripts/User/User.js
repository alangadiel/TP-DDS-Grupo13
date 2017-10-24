function login() {
    var form = $('#Form');
    var data = form.serialize();
    $.ajax({
        url: "/User/Login",
        type: "POST",
        data: data,
        dataType: "json",
        traditional: true,
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.status == "Success") {
                alert("Done");
                $(element).closest("form").submit(); //<------------ submit form
            } else {
                alert("Error occurs on the Database level!");
            }
        },
        error: function () {
            alert("An error has occured!!!");
        }
    });
}