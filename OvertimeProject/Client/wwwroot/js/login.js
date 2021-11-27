// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

/*function Login() {
    var objectInsert = new Object();
    objectInsert.Email = $("#Email").val();
    objectInsert.Password = $("#Password").val();
    $.ajax({
        url: 'https://localhost:44325/Login/auth',
        type: "POST",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        data: JSON.stringify(objectInsert),
        dataType: "json"
    }).done((result) => {
        console.log("resultDone: " + result);
        Swal.fire({
            position: 'center',
            icon: 'success',
            title: 'You Have Logged in',
            showConfirmButton: false,
            timer: 1500
        }) //buat alert pemberitahuan jika success
    }).fail((error) => {
        console.log("eror: " + error);
        alert("Wrong Email or Password");
        Swal.fire({
            position: 'center',
            icon: 'error',
            title: 'Wrong Email or Password!',
            showConfirmButton: false,
            timer: 2000
        });
    });
}*/
/*function showSignIn() {
    $("#sectionSignUp").hide();
    $("#sectionSignIn").show();
}
function showSignUp() {
    $("#sectionSignIn").hide();
    $("#sectionSignUp").show();
}*/

/*(function () {
    'use strict'

    // Fetch all the forms we want to apply custom Bootstrap validation styles to
    var forms = document.querySelectorAll('.needs-validation')

    // Loop over them and prevent submission
    Array.prototype.slice.call(forms)
        .forEach(function (form) {
            form.addEventListener('submit', function (event) {
                if (!form.checkValidity()) {
                    event.preventDefault()
                    event.stopPropagation()
                }

                form.classList.add('was-validated')
            }, false)
        })
})*/

$("#loginForm").validate({
    rules: {
        Email: {
            required: true,
            email: true
        },
        Password: {
            required: true
        }
    },
    messages: {
        Email: {
            required: "Please enter your email",
            email: "The email should be in the format: abc@domain.tld"
        },
        Password: {
            required: "Please enter your password"
        }
    },
    errorPlacement: function (error, element) {
        if (element.attr("name") == "Email")
            $("#Email-errorMsg").html(error);
        if (element.attr("name") == "Password")
            $("#Pass-errorMsg").html(error);
    }
});