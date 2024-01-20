async function getData() {
    try {
        const response = await fetch('/api/products');

        if (!response.ok) {
            throw new Error('Network response was not ok');
        }

        const data = await response.json();
        console.log(data);
        return data;
    } catch (error) {
        console.error('Error fetching data:', error);
    }
}

function forwardToDetail(productId) {
    window.localStorage.setItem("product-id", productId);
    window.location.href = "./fullpage";
}

async function fillTemplate() {
    try {
        const data = await getData();
        

        let output = "";

        console.log(data);

        for (let product of data) {
            output += `
                <div class="product" onclick="forwardToDetail(${product.id})">
                    <img src="${product.image}" alt="${product.image}">
                    <p class="title">${product.title}</p>
                    <p class="description">${product.description}</p>
                    <p class="price">
                        <span>${product.price} .- </span>
                    </p>
                </div>`;
        }



        document.querySelector(".products").innerHTML = output;
    } catch (error) {
        console.error('Error filling template:', error);
    }
}

fillTemplate();

