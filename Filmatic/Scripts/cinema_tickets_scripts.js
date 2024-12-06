const $containerSelectSeats = document.querySelector(".container-select-seats");
const $aisleOfRoom = document.querySelector(".aisle");

const $gridElementSection1 = document.querySelector(".grid-seats.section-1");
const $gridElementSection2 = document.querySelector(".grid-seats.section-2");


const $listSumary = document.querySelector(".summary-tickets .list-items-detail");

const NUM_ROWS = 7;
const NUM_COLS = 18;

const notAvaibleTickets = getDataSeatsNotAvailable();

let selectedTickets = [];


function loadDataDetailInSumaryElement() {

    $listSumary.innerHTML = ""

    selectedTickets.forEach(({row,col }) => {
        $listSumary.append(getElementItemSumary(row, col, 1, 5000))
    })

}

function getElementItemSumary(row, col, quantity, price) {

    const $listItemSumary = document.createElement("li")

    const $liContent = document.createElement("div");
    $liContent.classList.add("container-item");
    $liContent.innerHTML = `
        <div class="description">Tiquete ${row}${col} <div>
        <div class="quantity" >X${quantity}</div>
        <div class="price">Precio: ${price}</div>
        <button title="Eliminar" type="button" class="button-delete" onclick="manageSelectedTickets('${row}', '${col}')">🗑️</button>
    `

    $listItemSumary.append($liContent)
    return $listItemSumary;
}

function getElementNotAvailable(rowId, colId) {
    const $contentNotAvailable = document.createElement("div");
    $contentNotAvailable.classList.add("content-not-available");
    return $contentNotAvailable;
}

function getElementAvailable(rowId, colId) {
    const $contentAvailable = document.createElement("div");
    $contentAvailable.classList.add("content-available");
    $contentAvailable.innerHTML = `
  <div class="row-col-ticket">
    <span data-id-col="1">${colId}</span>
    <span data-id-row="1">${getAbecedaryByIdx(rowId)}</spa>
  <div>
  `;

    $contentAvailable.innerHTML += `<div><input type="checkbox"></div>`;
    return $contentAvailable;
}

function getElementSelected(rowId, colId) {
    const $contentSelected = document.createElement("div");
    $contentSelected.classList.add("content-selected");
    $contentSelected.innerHTML = `
  <div class="row-col-ticket">
    <span data-id-col="1">${colId}</span>
    <span data-id-row="1">${getAbecedaryByIdx(rowId)}</spa>
  <div>
  `;
    $contentSelected.innerHTML += `<div><input type="checkbox" checked></div>`;
    return $contentSelected;
}

function addSelectedTickets(_row, _col) {
    selectedTickets.push({ row: _row, col: _col });
}

function removeSelectedTickets(_row, _col) {
    selectedTickets = selectedTickets.filter(
        (item) => item.row != _row || item.col != _col
    );
}

function manageSelectedTickets(_row, _col) {
    const existSelected = selectedTickets.some(
        (item) => item.row == _row && item.col == _col
    );

    //* Si es igual se debe agregar
    if (!existSelected) {
        addSelectedTickets(_row, _col);
    } else {
        removeSelectedTickets(_row, _col);
    }

    printSeats(NUM_ROWS, NUM_COLS);
    loadDataDetailInSumaryElement()
}

function setNotAvailableClass() {
    notAvaibleTickets.forEach((item) => {
        const $seatSelected = document.querySelector(
            `[data-ds-idx-row="${item.row}"][data-ds-idx-col="${item.col}"]`
        );
        if ($seatSelected) {
            $seatSelected.classList.remove("available");
            $seatSelected.classList.add("not-available");
        }
    });
}

// Se encarga de colocar la clase de ccs al los elmentos seleccionados
function setSelectedClass() {
    selectedTickets.forEach((item) => {
        const $seatSelected = document.querySelector(
            `[data-ds-idx-row="${item.row}"][data-ds-idx-col="${item.col}"]`
        );
        $seatSelected.classList.remove("available");
        $seatSelected.classList.add("selected");
    });
}

function addEventListenerSeatsElement() {
    document.querySelectorAll(".grid-seats .item").forEach((item) => {
        item.addEventListener("click", (e) => {
            const rowId = item.getAttribute("data-ds-idx-row");
            const colId = item.getAttribute("data-ds-idx-col");
            manageSelectedTickets(rowId, colId);
            
        });
    });
}

function printSeats(numRows, numCols) {
    if (!Boolean(numRows > 0 && numRows > 0)) return;

    const leftCols = Number.parseInt(numCols / 2);
    const rightCols = numCols - leftCols;

    $gridElementSection1.innerHTML = "";
    $gridElementSection2.innerHTML = "";

    $gridElementSection1.setAttribute("data-ds-total-rows", numRows);
    $gridElementSection2.setAttribute("data-ds-total-rows", numRows);

    $gridElementSection1.setAttribute("data-ds-total-cols", leftCols);
    $gridElementSection2.setAttribute("data-ds-total-cols", rightCols);

    $gridElementSection1.style.gridTemplateColumns = `repeat(${leftCols}, 1fr)`;
    $gridElementSection2.style.gridTemplateColumns = `repeat(${rightCols}, 1fr)`;

    $gridElementSection1.style.gridTemplateRows = `repeat(${numRows}, 1fr)`;
    $gridElementSection2.style.gridTemplateRows = `repeat(${numRows}, 1fr)`;

    console.clear();
    const [clientRectGrid] = $containerSelectSeats.getClientRects();
    // console.log(clientRectGrid);

    let widthSquare = "100%";
    let heightSquare = "80px";

    // console.log({ widthSquare, heightSquare });

    for (let iRows = 0; iRows < numRows; iRows++) {
        for (let iCols = 1; iCols <= numCols; iCols++) {
            const $divElement = document.createElement("div");
            $divElement.setAttribute("data-ds-idx-row", getAbecedaryByIdx(iRows));
            $divElement.setAttribute("data-ds-idx-col", iCols);
            $divElement.classList.add("item-seat");
            $divElement.classList.add("available");
            $divElement.style.width = `${widthSquare}px`;
            $divElement.style.height = `${heightSquare}`;

            $divElement.append(getElementAvailable(iRows, iCols));
            $divElement.append(getElementNotAvailable(iRows, iCols));
            $divElement.append(getElementSelected(iRows, iCols));

            if (iCols <= leftCols) $gridElementSection1.append($divElement);
            else $gridElementSection2.append($divElement);
        }
    }

    setNotAvailableClass();
    setSelectedClass();

    const allItemsSeatsAvaible = document.querySelectorAll(
        ".grid-seats .item-seat.available, .grid-seats .item-seat.selected"
    );
    allItemsSeatsAvaible.forEach(($itemCinemaRoomSeat) => {
        $itemCinemaRoomSeat.addEventListener("click", (e) => {
            if ($itemCinemaRoomSeat.classList.contains("not-available")) return;
            const rowId = $itemCinemaRoomSeat.getAttribute("data-ds-idx-row");
            const colId = $itemCinemaRoomSeat.getAttribute("data-ds-idx-col");
            manageSelectedTickets(rowId, colId);
        });
    });
}


function getDataSeatsNotAvailable() {
    try {
        return JSON.parse(document.getElementById('jsonDataSeatsNotAvailable').textContent)
    } catch {
        return []
    }
}

function getAbecedaryByIdx(_idx = 0) {
    const abecedary = [
        "A",
        "B",
        "C",
        "D",
        "E",
        "F",
        "G",
        "H",
        "I",
        "J",
        "K",
        "L",
        "M",
        "N",
        "Ñ",
        "O",
        "P",
        "Q",
        "R",
        "S",
        "T",
        "U",
        "V",
        "W",
        "X",
        "Y",
        "Z"
    ];
    return abecedary[_idx];
}


printSeats(NUM_ROWS, NUM_COLS);
loadDataDetailInSumaryElement()