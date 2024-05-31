
$(document).ready(function () {
    $('#loginForm').submit(function (e) {
        e.preventDefault();
        var Name = $('#Name').val();
        var Passowrd = $('#Passowrd').val();

        $.ajax({
            url: '/api/Users/login',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify({ Name, Passowrd }),
            success: function (response) {
                console.log(response);
                localStorage.setItem('jwtToken', response);
                alert('Login successful.');
                window.location.href = '/customers.html'; // Redirect to customer list page
            },
            error: function (xhr, textStatus, errorThrown) {
                alert('Login failed. Please try again.');
            }
        });
    });
});
