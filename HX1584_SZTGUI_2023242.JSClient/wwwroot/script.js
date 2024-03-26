let customer = [];
let connection;
let customerIdToUpdate;

getData();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:64867/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("CustomerCreated", (user, message) => {
        getData();
    });
    connection.on("CustomerDeleted", (user, message) => {
        getData();
    });
    connection.on("CustomerUpdated", (user, message) => {
        getData();
    });
    connection.onclose
        (async () => {
            await start();
        });
    start();

}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getData(){
    await fetch('http://localhost:64867/customer')
        .then(x => x.json())
        .then(y => {
            customer = y;
            console.log(customer);
            displayCustomer()
        });
}
async function getItemData() {
    await fetch('http://localhost:64867/item')
        .then(x => x.json())
        .then(y => {
            items = y;
            console.log(items);
            displayItem()
        });
}

function displayCustomer() {
    document.getElementById('customerResult').innerHTML = "";
    customer.forEach(t => {
        document.getElementById('customerResult').innerHTML +=
            "<tr><td>" + t.customer_id + "</td><td>"
            + t.name + "</td><td>"
            + t.year + "</td><td>"
            + t.city + "</td><td>"
            + t.phone + "</td><td>"
            + t.cart_id + "</td><td>"
            + `<button type="button" onclick="remove(${t.customer_id})">Delete</button>`
            + `<button type="button" onclick="showUpdate(${t.customer_id})">Update</button>` + "</td></tr>";
        console.log()
    })
}

function createCustomer() {
    let name_new = document.getElementById("customerName").value;
    let age_new = document.getElementById("customerAge").value;
    let phone_new = document.getElementById("customerPhone").value;
    let city_new = document.getElementById("customerCity").value;

    fetch('http://localhost:64867/customer', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                city : city_new,
                phone : phone_new,
                name : name_new,
                year : age_new
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getData();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}

function remove(id) {
    fetch('http://localhost:64867/customer/' + id, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
        },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getData();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}

function showUpdate(id) {
    document.getElementById("customerNameUpdate").value = customer.find(x => x['customer_id'] == id)['name'];
    document.getElementById("customerAgeUpdate").value = customer.find(x => x['customer_id'] == id)['year'];
    document.getElementById("customerPhoneUpdate").value = customer.find(x => x['customer_id'] == id)['phone'];
    document.getElementById("customerCityUpdate").value = customer.find(x => x['customer_id'] == id)['city'];
    document.getElementById("updateFormdiv").style.display = 'flex';
    customerIdToUpdate = id;
}

function updateCustomer(id) {
    document.getElementById("updateFormdiv").style.display = 'none';
    let name_update = document.getElementById("customerNameUpdate").value;
    let age_update = document.getElementById("customerAgeUpdate").value;
    let phone_update = document.getElementById("customerPhoneUpdate").value;
    let city_update = document.getElementById("customerCityUpdate").value;

    fetch('http://localhost:64867/customer', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                city: city_update,
                phone: phone_update,
                name: name_update,
                year: age_update,
                customer_id: customerIdToUpdate
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getData();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}