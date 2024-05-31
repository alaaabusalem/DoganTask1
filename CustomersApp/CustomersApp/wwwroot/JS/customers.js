$(document).ready(function () {
    let token = localStorage.getItem('jwtToken');

    function loadCustomers() {
        $.ajax({
            url: '/api/Customers/GetAll',
            method: 'GET',
            headers: {
                'Authorization': 'Bearer ' + token
            },
            success: function (customers) {
                console.log(customers);
                const tbody = $('#customersTable tbody');
                tbody.empty();
                $.each(customers, function (index, customer) {
                    tbody.append(`
                        <tr>
                            <td>${customer.id}</td>
                            <td>${customer.name}</td>
                            <td>${customer.email}</td>
                            <td>${customer.phone}</td>
                            <td>
                                <button class="btn btn-primary editCustomer" data-id="${customer.id}">Edit</button>
                                <button class="btn btn-danger deleteCustomer" data-id="${customer.id}">Delete</button>
                            </td>
                        </tr>
                    `);
                });

                // Edit customer
                $('.editCustomer').click(function () {
                    const id = parseInt($(this).data('id'));
                    window.location.href = `customerForm.html?id=${id}`;
                });

                // Delete customer
                $('.deleteCustomer').click(function () {
                    const id = $(this).data('id');
                    if (confirm('Are you sure you want to delete this customer?')) {
                        $.ajax({
                            url: `/api/Customers/Remove/${id}`,
                            method: 'DELETE',
                            headers: {
                                'Authorization': 'Bearer ' + token
                            },
                            success: function () {
                                alert('Customer deleted successfully');
                                loadCustomers();
                            },
                            error: function (xhr) {
                                console.error('Error:', xhr.responseText); 
                                alert('Failed to delete customer');
                            }
                        });
                    }
                });
            },
            error: function (xhr, textStatus, errorThrown) {
                console.error('Error:', xhr); 
                alert('Failed to fetch customer list. Please try again later.');
            }
        });
    }

    loadCustomers();

    // Create customer
    $('#createCustomer').click(function () {
        window.location.href = 'customerForm.html';
    });
});
