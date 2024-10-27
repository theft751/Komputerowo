
let selectedRate = {};
let rateInAddReviewForm = {};

function clearStarsInAddReviewForm(firstStarInAddReviewForm, secondStarInAddReviewForm, thirdStarInAddReviewForm, fourthStarInAddReviewForm, fifthStarInAddReviewForm) {

    firstStarInAddReviewForm.className = "demo-icon icon-star-empty";
    secondStarInAddReviewForm.className = "demo-icon icon-star-empty";
    thirdStarInAddReviewForm.className = "demo-icon icon-star-empty";
    fourthStarInAddReviewForm.className = "demo-icon icon-star-empty";
    fifthStarInAddReviewForm.className = "demo-icon icon-star-empty";
}


function setStarsInAddReviewForm(rate, firstStarInAddReviewForm, secondStarInAddReviewForm, thirdStarInAddReviewForm, fourthStarInAddReviewForm, fifthStarInAddReviewForm, selectedRateId) {
    clearStarsInAddReviewForm(firstStarInAddReviewForm, secondStarInAddReviewForm, thirdStarInAddReviewForm, fourthStarInAddReviewForm, fifthStarInAddReviewForm);
    selectedRate[selectedRateId] = rate;
    rateInAddReviewForm[selectedRateId].value = rate;
    switch (rate) {
        case 10:
            fifthStarInAddReviewForm.className = "demo-icon icon-star";
        case 8:
            fourthStarInAddReviewForm.className = "demo-icon icon-star";
        case 6:
            thirdStarInAddReviewForm.className = "demo-icon icon-star";
        case 4:
            secondStarInAddReviewForm.className = "demo-icon icon-star";
        case 2:
            firstStarInAddReviewForm.className = "demo-icon icon-star";

    }
}

function tempSetStarsInAddReviewForm(rate, firstStarInAddReviewForm, secondStarInAddReviewForm, thirdStarInAddReviewForm, fourthStarInAddReviewForm, fifthStarInAddReviewForm) {

    clearStarsInAddReviewForm(firstStarInAddReviewForm, secondStarInAddReviewForm, thirdStarInAddReviewForm, fourthStarInAddReviewForm, fifthStarInAddReviewForm);

    switch (rate) {
        case 10:
            fifthStarInAddReviewForm.className = "demo-icon icon-star";
        case 8:
            fourthStarInAddReviewForm.className = "demo-icon icon-star";
        case 6:
            thirdStarInAddReviewForm.className = "demo-icon icon-star";
        case 4:
            secondStarInAddReviewForm.className = "demo-icon icon-star";
        case 2:
            firstStarInAddReviewForm.className = "demo-icon icon-star";

    }
}

function tempUnsetStarsInAddReviewForm(firstStarInAddReviewForm, secondStarInAddReviewForm, thirdStarInAddReviewForm, fourthStarInAddReviewForm, fifthStarInAddReviewForm, selectedRateId) {

    clearStarsInAddReviewForm(firstStarInAddReviewForm, secondStarInAddReviewForm, thirdStarInAddReviewForm, fourthStarInAddReviewForm, fifthStarInAddReviewForm);

    switch (selectedRate[selectedRateId]) {
        case 10:
            fifthStarInAddReviewForm.className = "demo-icon icon-star";
        case 8:
            fourthStarInAddReviewForm.className = "demo-icon icon-star";
        case 6:
            thirdStarInAddReviewForm.className = "demo-icon icon-star";
        case 4:
            secondStarInAddReviewForm.className = "demo-icon icon-star";
        case 2:
            firstStarInAddReviewForm.className = "demo-icon icon-star";
    }
}



function setDisplayImage(id) {
    document.getElementById("SelectedImageDisplay").src = document.getElementById(id).src;
}


function initializeStarRating(id, initialValue)
{


    //Rate stars in Add review form operations 
    let firstStarInAddReviewForm = document.getElementById("firstStarInAddReviewForm-" + id);
    let secondStarInAddReviewForm = document.getElementById("secondStarInAddReviewForm-" + id);
    let thirdStarInAddReviewForm = document.getElementById("thirdStarInAddReviewForm-" + id);
    let fourthStarInAddReviewForm = document.getElementById("fourthStarInAddReviewForm-" + id);
    let fifthStarInAddReviewForm = document.getElementById("fifthStarInAddReviewForm-" + id);
    rateInAddReviewForm[id] = document.getElementById("rateInAddReviewForm-" + id);

    setStarsInAddReviewForm(initialValue, firstStarInAddReviewForm, secondStarInAddReviewForm, thirdStarInAddReviewForm, fourthStarInAddReviewForm, fifthStarInAddReviewForm, id);


    //initialize event listeners
    firstStarInAddReviewForm.addEventListener("click", () => { setStarsInAddReviewForm(2, firstStarInAddReviewForm, secondStarInAddReviewForm, thirdStarInAddReviewForm, fourthStarInAddReviewForm, fifthStarInAddReviewForm, id); });
    secondStarInAddReviewForm.addEventListener("click", () => { setStarsInAddReviewForm(4, firstStarInAddReviewForm, secondStarInAddReviewForm, thirdStarInAddReviewForm, fourthStarInAddReviewForm, fifthStarInAddReviewForm, id); });
    thirdStarInAddReviewForm.addEventListener("click", () => { setStarsInAddReviewForm(6, firstStarInAddReviewForm, secondStarInAddReviewForm, thirdStarInAddReviewForm, fourthStarInAddReviewForm, fifthStarInAddReviewForm, id); });
    fourthStarInAddReviewForm.addEventListener("click", () => { setStarsInAddReviewForm(8, firstStarInAddReviewForm, secondStarInAddReviewForm, thirdStarInAddReviewForm, fourthStarInAddReviewForm, fifthStarInAddReviewForm, id); });
    fifthStarInAddReviewForm.addEventListener("click", () => { setStarsInAddReviewForm(10, firstStarInAddReviewForm, secondStarInAddReviewForm, thirdStarInAddReviewForm, fourthStarInAddReviewForm, fifthStarInAddReviewForm, id); });

    firstStarInAddReviewForm.addEventListener("mouseover", () => { tempSetStarsInAddReviewForm(2, firstStarInAddReviewForm, secondStarInAddReviewForm, thirdStarInAddReviewForm, fourthStarInAddReviewForm, fifthStarInAddReviewForm); });
    secondStarInAddReviewForm.addEventListener("mouseover", () => { tempSetStarsInAddReviewForm(4, firstStarInAddReviewForm, secondStarInAddReviewForm, thirdStarInAddReviewForm, fourthStarInAddReviewForm, fifthStarInAddReviewForm); });
    thirdStarInAddReviewForm.addEventListener("mouseover", () => { tempSetStarsInAddReviewForm(6, firstStarInAddReviewForm, secondStarInAddReviewForm, thirdStarInAddReviewForm, fourthStarInAddReviewForm, fifthStarInAddReviewForm); });
    fourthStarInAddReviewForm.addEventListener("mouseover", () => { tempSetStarsInAddReviewForm(8, firstStarInAddReviewForm, secondStarInAddReviewForm, thirdStarInAddReviewForm, fourthStarInAddReviewForm, fifthStarInAddReviewForm); });
    fifthStarInAddReviewForm.addEventListener("mouseover", () => { tempSetStarsInAddReviewForm(10, firstStarInAddReviewForm, secondStarInAddReviewForm, thirdStarInAddReviewForm, fourthStarInAddReviewForm, fifthStarInAddReviewForm); });

    firstStarInAddReviewForm.addEventListener("mouseout", () => { tempUnsetStarsInAddReviewForm(firstStarInAddReviewForm, secondStarInAddReviewForm, thirdStarInAddReviewForm, fourthStarInAddReviewForm, fifthStarInAddReviewForm, id); });
    secondStarInAddReviewForm.addEventListener("mouseout", () => { tempUnsetStarsInAddReviewForm(firstStarInAddReviewForm, secondStarInAddReviewForm, thirdStarInAddReviewForm, fourthStarInAddReviewForm, fifthStarInAddReviewForm, id); });
    thirdStarInAddReviewForm.addEventListener("mouseout", () => { tempUnsetStarsInAddReviewForm(firstStarInAddReviewForm, secondStarInAddReviewForm, thirdStarInAddReviewForm, fourthStarInAddReviewForm, fifthStarInAddReviewForm, id); });
    fourthStarInAddReviewForm.addEventListener("mouseout", () => { tempUnsetStarsInAddReviewForm(firstStarInAddReviewForm, secondStarInAddReviewForm, thirdStarInAddReviewForm, fourthStarInAddReviewForm, fifthStarInAddReviewForm, id); });
    fifthStarInAddReviewForm.addEventListener("mouseout", () => { tempUnsetStarsInAddReviewForm(firstStarInAddReviewForm, secondStarInAddReviewForm, thirdStarInAddReviewForm, fourthStarInAddReviewForm, fifthStarInAddReviewForm, id); });
}