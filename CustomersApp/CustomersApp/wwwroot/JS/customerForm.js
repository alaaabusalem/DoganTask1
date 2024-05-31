$(document).ready(function () {
    const urlParams = new URLSearchParams(window.location.search);
    const customerId = urlParams.get('id');
   
    if (customerId) {

        $('#formTitle').text('Edit Customer');

      
        $.ajax({
            url: `/api/customers/GetById/${customerId}`,
            method: 'GET',
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('jwtToken')
            },
            success: function (customer) {
                $('#id').val(customer.id);
                $('#name').val(customer.name);
                $('#email').val(customer.email);
                $('#phone').val(customer.phone);
            },
            error: function (xhr, textStatus, errorThrown) {
                console.error('Error:', xhr);
                alert('Failed to load customer details. Please try again later.');
            }
        });
    }

    $('#customerForm').submit(function (event) {
        event.preventDefault();

        // Get form data
        const id = $('#id').val();
        const name = $('#name').val();
        const email = $('#email').val();
        const phone = $('#phone').val();

        const customer = {
            name: name,
            email: email,
            phone: phone
        };

       
        let url = '/api/customers/';
        let method = 'POST';
        if (customerId) {

            url += `update/Customer/${customerId}`;
            method = 'PUT';
        }
        else {
            url += `Create/Customer`;

        }
        // Send POST/PUT request to create/update customer
        $.ajax({
            url: url,
            method: method,
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('jwtToken'),
                'Content-Type': 'application/json'
            },
            data: JSON.stringify(customer),
            success: function () {
                alert('Customer saved successfully');
                window.location.href = 'customers.html'; 
            },
            error: function (xhr, textStatus, errorThrown) {
                console.error('Error:', xhr);
                alert('Failed to save customer. Please try again later.');
            }
        });
    });
});

