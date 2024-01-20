async function submitLoginForm(e) {
    e.preventDefault();

    const image = document.querySelector('#image').value;
    const title = document.querySelector('#title').value;
    const description = document.querySelector('#description').value;
    const price = document.querySelector('#price').value;

    try {
        await addProduct(image, title, description, price);
        window.alert("Das Produkt wurde hinzugefuegt!")
    } catch (err) {
        document.querySelector('#add-error').innerText = err.message;
    }

    console.log("image: " + image);
    console.log("title: " + title);
    console.log("description: " + description);
    console.log("price: " + price);
}

document.querySelector('form').addEventListener('submit', submitLoginForm);

async function addProduct(image, title, description, price) {
    const request = await fetch(`https://localhost:7257/api/products/`, {
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        cache: 'no-cache',
        method: 'POST',
        body: JSON.stringify({ 'Image': image, 'Title': title, 'Description': description, 'Price': price })
    });

    if (!request.ok) {
        const errorData = await request.json();
        throw new Error(errorData.message);
    }

    
}
