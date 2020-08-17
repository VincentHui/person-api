const uri = "api/Person";
function addItem() {
  const addNameTextbox = document.getElementById("add-name");

  const person = {
    name: addNameTextbox.value,
  };

  fetch(uri, {
    method: "POST",
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json",
    },
    body: JSON.stringify(person),
  })
    .then((resp) => {
      addNameTextbox.value = "";
      return resp.json();
    })
    .then((data) => console.log(data))
    .catch((error) => console.error("Unable to add person.", error));
}
