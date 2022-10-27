
let h = this.document.querySelector("header");

window.addEventListener('scroll', function() {
    if(window.pageYOffset > 180 ){
        h.classList.add("shrunk");
        
    }
    else{
        h.classList.remove("shrunk")
    }
  }); 


  let pizza_type = $('#next_pizza').val(); 
  $("#add_next_pizza").on("click", function(event) {
    event.preventDefault();
    let pizza_type = $("#next_pizza").val();
    let pizza_number = 1 + $(".a_pizza").length;
    let pizza_entry = `<li class='a_pizza'>
      <p>${pizza_type}</p>
      <div class='flex-inner'>
        <label><input type='checkbox' name='hot[${pizza_number}]'> That's hot</label>
        <label><input type='checkbox' name='cheese[${pizza_number}]'>Mit extra Cheese</label>
        <label><input type='checkbox' name='fuer[${pizza_number}]' placeholder='Enter Name Here'></label>
        <input name='pizza[${pizza_number}]' value='${pizza_type}' type='hidden'>
        </div>
      </li>`;
      let $li = $(this).parents("li");
     $li.after(pizza_entry);
  });
  