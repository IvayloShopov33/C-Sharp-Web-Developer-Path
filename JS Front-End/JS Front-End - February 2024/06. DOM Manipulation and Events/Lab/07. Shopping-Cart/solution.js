function solve() {
   const addButtonElements = document.querySelectorAll('button.add-product');
   const outputTextArea = document.querySelector('textarea');
   const checkoutButtonElement = document.querySelector('button.checkout');
   const uniqueProducts = new Set();
   let totalPrice = 0;

   for (const addButtonElement of addButtonElements) {
      //const productElement = addButtonElement.closest('.product');
      const productElement = addButtonElement.parentNode.parentNode;

      addButtonElement.addEventListener('click', () => {
         const productName = productElement.querySelector('.product-title').textContent;
         uniqueProducts.add(productName);

         let productPrice = productElement.querySelector('.product-line-price').textContent;
         productPrice = Number(productPrice);
         totalPrice += productPrice;

         outputTextArea.textContent += `Added ${productName} for ${productPrice.toFixed(2)} to the cart.\n`;
      });
   }

   checkoutButtonElement.addEventListener('click', () => {
      Array.from(addButtonElements).forEach(addButton => addButton.setAttribute('disabled', 'disabled'));
      checkoutButtonElement.setAttribute('disabled', 'disabled');

      outputTextArea.textContent += `You bought ${Array.from(uniqueProducts).join(', ')} for ${totalPrice.toFixed(2)}.`;
   });
}