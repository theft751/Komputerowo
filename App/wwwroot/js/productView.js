
let selectedRate = 2;

function clearStarsInAddReviewForm() {

    firstStarInAddReviewForm.className = "demo-icon icon-star-empty";
    secondStarInAddReviewForm.className = "demo-icon icon-star-empty";
    thirdStarInAddReviewForm.className = "demo-icon icon-star-empty";
    fourthStarInAddReviewForm.className = "demo-icon icon-star-empty";
    fifthStarInAddReviewForm.className = "demo-icon icon-star-empty";
    fifthStarInAddReviewForm.className = "demo-icon icon-star-empty";
}


function setStarsInAddReviewForm(rate) {
    clearStarsInAddReviewForm();
    selectedRate = rate;
    rateInAddReviewForm.value = rate;
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

function tempSetStarsInAddReviewForm(rate) {

    clearStarsInAddReviewForm();

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

function tempUnsetStarsInAddReviewForm() {

    clearStarsInAddReviewForm();

    switch (selectedRate) {
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



//Rate stars in Add review form operations 
const firstStarInAddReviewForm = document.getElementById("firstStarInAddReviewForm");
const secondStarInAddReviewForm = document.getElementById("secondStarInAddReviewForm");
const thirdStarInAddReviewForm = document.getElementById("thirdStarInAddReviewForm");
const fourthStarInAddReviewForm = document.getElementById("fourthStarInAddReviewForm");
const fifthStarInAddReviewForm = document.getElementById("fifthStarInAddReviewForm");
const rateInAddReviewForm = document.getElementById("rateInAddReviewForm");

firstStarInAddReviewForm.addEventListener("click", () => { setStarsInAddReviewForm(2); });
secondStarInAddReviewForm.addEventListener("click", () => { setStarsInAddReviewForm(4); });
thirdStarInAddReviewForm.addEventListener("click", () => { setStarsInAddReviewForm(6); });
fourthStarInAddReviewForm.addEventListener("click", () => { setStarsInAddReviewForm(8); });
fifthStarInAddReviewForm.addEventListener("click", () => { setStarsInAddReviewForm(10); });

firstStarInAddReviewForm.addEventListener("mouseover", () => { tempSetStarsInAddReviewForm(2); });
secondStarInAddReviewForm.addEventListener("mouseover", () => { tempSetStarsInAddReviewForm(4); });
thirdStarInAddReviewForm.addEventListener("mouseover", () => { tempSetStarsInAddReviewForm(6); });
fourthStarInAddReviewForm.addEventListener("mouseover", () => { tempSetStarsInAddReviewForm(8); });
fifthStarInAddReviewForm.addEventListener("mouseover", () => { tempSetStarsInAddReviewForm(10); });

firstStarInAddReviewForm.addEventListener("mouseout", () => { tempUnsetStarsInAddReviewForm(); });
secondStarInAddReviewForm.addEventListener("mouseout", () => { tempUnsetStarsInAddReviewForm(); });
thirdStarInAddReviewForm.addEventListener("mouseout", () => { tempUnsetStarsInAddReviewForm(); });
fourthStarInAddReviewForm.addEventListener("mouseout", () => { tempUnsetStarsInAddReviewForm(); });
fifthStarInAddReviewForm.addEventListener("mouseout", () => { tempUnsetStarsInAddReviewForm(); });

function setDisplayImage(id) {
    document.getElementById("SelectedImageDisplay").src = document.getElementById(id).src;
}
function editReviewShow(reviewDTOId) {
    let review = document.getElementById("review-" + reviewDTOId);
    let editRevievForm = document.getElementById("edit-reviev-form-" + reviewDTOId);
    let editReviewTextArea = document.getElementById("edit-review-textarea-" + reviewDTOId);

    review.hidden = true;
    editRevievForm.hidden = false;
    editReviewTextArea.focus();
}