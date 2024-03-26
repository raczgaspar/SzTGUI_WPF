let customer = [];
let items = [];
let orders = [];
let connection;
let customerIdToUpdate;
let itemIdUpdate;
let orderIdUpdate;

var path = window.location.pathname;
var page = path.split("/").pop();
switch (page) {
    case 'index.html': getData(); break;
    case 'items.html': getItemData(); break;
    case 'order.html': getOrderData(); break;

    default:getData()
}

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
    connection.on("ItemUpdated", (user, message) => {
        getItemData();
    });
    connection.on("ItemDeleted", (user, message) => {
        getItemData();
    });
    connection.on("ItemCreated", (user, message) => {
        getItemData();
    });
    connection.on("OrderCreated", (user, message) => {
        getOrderData();
    });
    connection.on("OrderUpdated", (user, message) => {
        getOrderData();
    });
    connection.on("OrderDeleted", (user, message) => {
        getOrderData();
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
async function getOrderData() {
    await fetch('http://localhost:64867/order')
        .then(x => x.json())
        .then(y => {
            orders = y;
            console.log(orders);
            displayOrder()
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
function displayItem() {
    document.getElementById('itemResult').innerHTML = "";
    items.forEach(t => {
        document.getElementById('itemResult').innerHTML +=
            "<tr><td>" + t.item_id + "</td><td>"
            + t.productName + "</td><td>"
            + t.price + "</td><td>"
            + t.year_of_man + "</td><td>"
            + t.fabr_country + "</td><td>"
            + `<button type="button" onclick="removeItem(${t.item_id})">Delete</button>`
            + `<button type="button" onclick="showUpdateItem(${t.item_id})">Update</button>` + "</td></tr>";
        console.log()
    })
}
function displayOrder() {
    document.getElementById('orderResult').innerHTML = "";
    orders.forEach(t => {
        document.getElementById('orderResult').innerHTML +=
            "<tr><td>" + t.order_id + "</td><td>"
            + t.item_id + "</td><td>"
            + t.cart_id + "</td><td>"
        + t.amount + "</td><td>"
            + `<button type="button" onclick="removeOrder(${t.order_id})">Delete</button>`
            + `<button type="button" onclick="showUpdateOrder(${t.order_id})">Update</button>` + "</td></tr>";
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
function createItem() {
    let id_new = document.getElementById("itemId").value;
    let name_new = document.getElementById("itemName").value;
    let price_new = document.getElementById("itemPrice").value;
    let yom_new = document.getElementById("itemYear").value;
    let fc_new = document.getElementById("itemCountry").value;

    fetch('http://localhost:64867/item', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                fabr_country : fc_new,
                item_id : id_new,
                price : price_new,
                productName : name_new,
                year_of_man : yom_new
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
function createOrder() {
    let id_new = document.getElementById("orderId").value;
    let item_new = document.getElementById("orderItem").value;
    let cart_new = document.getElementById("orderCart").value;
    let amo_new = document.getElementById("orderAmount").value;
    
    fetch('http://localhost:64867/order', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                order_id: id_new,
                item_id: item_new,
                cart_id: cart_new,
                amount: amo_new,
                Item : null
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getOrderData();
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
function removeItem(id) {
    fetch('http://localhost:64867/item/' + id, {
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
function removeOrder(id) {
    fetch('http://localhost:64867/order/' + id, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
        },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getOrderData();
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
function showUpdateItem(id) {
    document.getElementById("itemIdUpdate").value = items.find(x => x['item_id'] == id)['item_id'];
    document.getElementById("itemNameUpdate").value = items.find(x => x['item_id'] == id)['productName'];
    document.getElementById("itemPriceUpdate").value = items.find(x => x['item_id'] == id)['price'];
    document.getElementById("itemCountryUpdate").value = items.find(x => x['item_id'] == id)['fabr_country'];
    document.getElementById("itemYearUpdate").value = items.find(x => x['item_id'] == id)['year_of_man'];
    document.getElementById("updateFormdiv").style.display = 'flex';
    itemIdUpdate = id;
}
function showUpdateOrder(id) {
    document.getElementById("orderIdUpdate").value = orders.find(x => x['order_id'] == id)['order_id'];
    document.getElementById("orderItemUpdate").value = orders.find(x => x['order_id'] == id)['item_id'];
    document.getElementById("orderCartUpdate").value = orders.find(x => x['order_id'] == id)['cart_id'];
    document.getElementById("orderAmountUpdate").value = orders.find(x => x['order_id'] == id)['amount'];
    document.getElementById("updateFormdiv").style.display = 'flex';
    orderIdUpdate = id;
}

function updateCustomer() {
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
function updateItem() {
    document.getElementById("updateFormdiv").style.display = 'none';
    let id_update = document.getElementById("itemIdUpdate").value;
    let name_update = document.getElementById("itemNameUpdate").value;
    let price_update = document.getElementById("itemPriceUpdate").value;
    let yom_update = document.getElementById("itemYearUpdate").value;
    let fc_update = document.getElementById("itemCountryUpdate").value;

    fetch('http://localhost:64867/item', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                fabr_country: fc_update,
                item_id: id_update,
                price: price_update,
                productName: name_update,
                year_of_man: yom_update
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
function updateOrder() {
    document.getElementById("updateFormdiv").style.display = 'none';
    let id_update = document.getElementById("orderIdUpdate").value;
    let item_update = document.getElementById("orderItemUpdate").value;
    let cart_update = document.getElementById("orderCartUpdate").value;
    let amo_update = document.getElementById("orderAmountUpdate").value;
    let item = orders.find(x => x['order_id'] == orderIdUpdate)['item'];

    fetch('http://localhost:64867/order', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                order_id: id_update,
                item_id: item_update,
                cart_id: cart_update,
                amount: amo_update,
                
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getOrderData();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}