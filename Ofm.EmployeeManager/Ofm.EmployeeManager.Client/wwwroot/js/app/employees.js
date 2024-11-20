const host = "https://localhost:7298"
const PhotoBase64 = "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"

newEmployee()

$(document).ready(function () {
    getEmployees()
});

$("#saveEmployee").on("click", function () {
    const employee = {
        employeeId: 1,
        employeeFirstName: $("#employeeFirstName").val(),
        employeeLastName: $("#employeeLastName").val(),
        employeeEmail: $("#employeeEmail").val(),
        employeeEmailCompany: $("#employeeEmailCompany").val(),
        employeePassword: $("#employeePassword").val(),
        employeeSalary: parseFloat($("#employeeSalary").val()),
        typeEmployeeId: parseInt($("#typeEmployeeId").val()),
        photoInBase64: PhotoBase64
    };

    insertEmployee(employee)
});

$("#updateEmployee").on("click", function () {
    const employee = {
        employeeId: $("#employeeId").val(),
        employeeFirstName: $("#employeeFirstName").val(),
        employeeLastName: $("#employeeLastName").val(),
        employeeEmail: $("#employeeEmail").val(),
        employeeEmailCompany: $("#employeeEmailCompany").val(),
        employeePassword: $("#employeePassword").val(),
        employeeSalary: parseFloat($("#employeeSalary").val()),
        typeEmployeeId: parseInt($("#typeEmployeeId").val()),
        photoInBase64: PhotoBase64
    };

    $("#saveEmployee").hide()
    $("#updateEmployee").show()

    updateEmployee(employee)
});

function newEmployee() {
    $("#saveEmployee").show()
    $("#updateEmployee").hide()
};

function editEmployee(employeeId) {
    getEmployeeById(employeeId)
    $("#saveEmployee").hide()
    $("#updateEmployee").show()
};

function getEmployees() {
    $.ajax({
        url: `${host}/api/Employee/GetEmployees`,
        method: 'GET',
        dataType: 'json',
        success: function (response) {
            const employees = response.object;
            const $tableBody = $('#TableEmployees');

            employees.forEach((employee, index) => {
                const salaryFormatted = employee.employeeSalary.toLocaleString('en-US', { style: 'currency', currency: 'USD' });
                const row = `
                        <tr>
                            <td>${index + 1}</td>
                            <td>${employee.employeeFirstName}</td>
                            <td>${employee.employeeLastName}</td>
                            <td>${salaryFormatted}</td>
                            <td>${employee.typeEmployeeId}</td>
                            <td>
                                <button type="button" class="btn btn-outline-secondary editEmployee" onclick="editEmployee(${employee.employeeId})" data-bs-toggle="modal" data-bs-target="#employeeModal">
                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pencil-square" viewBox="0 0 16 16">
                                        <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z" />
                                        <path fill-rule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5z" />
                                    </svg>
                                </button>
                                <button type="button" class="btn btn-outline-secondary" onclick="deleteEmployee(${employee.employeeId})">
                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash3-fill" viewBox="0 0 16 16">
                                        <path d="M11 1.5v1h3.5a.5.5 0 0 1 0 1h-.538l-.853 10.66A2 2 0 0 1 11.115 16h-6.23a2 2 0 0 1-1.994-1.84L2.038 3.5H1.5a.5.5 0 0 1 0-1H5v-1A1.5 1.5 0 0 1 6.5 0h3A1.5 1.5 0 0 1 11 1.5m-5 0v1h4v-1a.5.5 0 0 0-.5-.5h-3a.5.5 0 0 0-.5.5M4.5 5.029l.5 8.5a.5.5 0 1 0 .998-.06l-.5-8.5a.5.5 0 1 0-.998.06m6.53-.528a.5.5 0 0 0-.528.47l-.5 8.5a.5.5 0 0 0 .998.058l.5-8.5a.5.5 0 0 0-.47-.528M8 4.5a.5.5 0 0 0-.5.5v8.5a.5.5 0 0 0 1 0V5a.5.5 0 0 0-.5-.5" />
                                    </svg>
                                </button>
                            </td>
                        </tr>
                    `;

                $tableBody.append(row);
            });
        },
        error: function (xhr, status, error) {
            console.error("Error al obtener la lista de empleados:", status, error);
        }
    });
}

function getEmployeeById(employeeId) {
    $.ajax({
        url: `${host}/api/Employee/GetGetEmployeeById/${employeeId}`, // Reemplaza con la URL de tu API
        method: 'GET',
        dataType: 'json',
        success: function (response) {
            let employee = response.object

            $("#employeeId").val(employee.employeeId);
            $("#employeeFirstName").val(employee.employeeFirstName);
            $("#employeeLastName").val(employee.employeeLastName);
            $("#employeeEmail").val(employee.employeeEmail);
            $("#employeeEmailCompany").val(employee.employeeEmailCompany);
            $("#employeePassword").val(employee.employeePassword);
            $("#employeeSalary").val(employee.employeeSalary);
            $("#typeEmployeeId").val(employee.typeEmployeeId);
        },
        error: function (xhr, status, error) {
            console.error("Error al obtener el empleado:", status, error);
        }
    });
}

function insertEmployee(employee) {
    $.ajax({
        url: `${host}/api/Employee/InsertEmployee`, // Cambia la URL según tu API
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(employee),
        success: function (response) {
            Swal.fire({
                title: "Empleado insertado con éxito!",
                icon: "success"
            }).then(() => {
                location.reload();
            });
        },
        error: function (error) {
            console.error("Error al insertar el empleado:", error);
        }
    });
}

function updateEmployee(employee) {
    $.ajax({
        url: `${host}/api/Employee/UpdateEmployee`, // Cambia la URL según tu API
        type: 'PUT',
        contentType: 'application/json',
        data: JSON.stringify(employee),
        success: function (response) {
            Swal.fire({
                title: "Empleado actualizado con éxito",
                icon: "success"
            }).then(() => {
                location.reload();
            });
        },
        error: function (error) {
            console.error("Error al actualizar el empleado:", error);
        }
    });
}

function deleteEmployee(employeeId) {
    $.ajax({
        url: `${host}/api/Employee/DeleteEmployee/${employeeId}`, // Cambia la URL según tu API
        type: 'DELETE',
        success: function (response) {
            Swal.fire({
                title: "Empleado eliminado con éxito",
                icon: "success"
            }).then(() => {
                location.reload();
            });
        },
        error: function (error) {
            console.error("Error al eliminar el empleado:", error);
        }
    });
}