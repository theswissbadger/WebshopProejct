async function renderDetail() {
    const id = localStorage.getItem("product-id");
    const res = await fetch(`/api/products/${id}`);
    const prod = await res.json();

    console.log(prod);

    let output = "";

    for (let data of prod) {
        output += `
                <div class="product">
                    <img src="${data.image}" alt="${data.image}">
                    <p class="title">${data.title}</p>
                    <p class="description">${data.description}</p>
                    <p class="price">
                        <span>${data.price}</span>
                    </p>
                </div>`;
    }



    document.querySelector(".products").innerHTML = output;

    
}

renderDetail();