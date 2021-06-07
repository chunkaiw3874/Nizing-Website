//drag scroll div
function dragScroll() {
    const ele = document.querySelector('.drag-scroll');
    ele.style.cursor = 'grab';

    let pos = { top: 0, left: 0, x: 0, y: 0 };

    const mouseDownHandler = function (e) {
        ele.style.cursor = 'grabbing';
        ele.style.userSelect = 'none';

        pos = {
            left: ele.scrollLeft,
            top: ele.scrollTop,
            // Get the current mouse position
            x: e.clientX,
            y: e.clientY,
        };

        document.addEventListener('mousemove', mouseMoveHandler);
        document.addEventListener('mouseup', mouseUpHandler);
    };

    const mouseMoveHandler = function (e) {
        // How far the mouse has been moved
        const dx = e.clientX - pos.x;
        const dy = e.clientY - pos.y;

        // Scroll the element
        ele.scrollTop = pos.top - dy;
        ele.scrollLeft = pos.left - dx;
    };

    const mouseUpHandler = function () {
        ele.style.cursor = 'grab';
        ele.style.removeProperty('user-select');

        document.removeEventListener('mousemove', mouseMoveHandler);
        document.removeEventListener('mouseup', mouseUpHandler);
    };

    // Attach the handler
    ele.addEventListener('mousedown', mouseDownHandler);
}


/*mini-menu slider*/
function sideScroll(element, direction, speed, distance, step) {
    scrollAmount = 0;
    var slideTimer = setInterval(function () {
        if (direction == 'left') {
            element[0].scrollLeft -= step;
        } else {
            element[0].scrollLeft += step;
        }
        scrollAmount += step;
        if (scrollAmount >= distance) {
            window.clearInterval(slideTimer);
        }
    }, speed);
}

function detectScrolling(element) {
    element.scroll(function () {
        var $width = element.outerWidth();
        var $scrollWidth = element[0].scrollWidth;
        var $scrollLeft = element.scrollLeft();

        toggleIndividualNavigationArrows($width, $scrollWidth, $scrollLeft);
    });
}

function isOverflowing(element) {
    return (element[0].scrollWidth > element[0].offsetWidth);
}

function toggleNavigationArrow(element) {
    var $width = element.outerWidth;
    var $scrollWidth = element[0].scrollWidth;
    var $scrollLeft = element.scrollLeft();

    if (isOverflowing(element)) {
        toggleIndividualNavigationArrows($width, $scrollWidth, $scrollLeft);
    } else {
        $('.arrow-container').css('visibility', 'hidden');
    }
}

function toggleIndividualNavigationArrows(width, scrollWidth, scrollLeft) {
    if (scrollWidth - width === scrollLeft) {
        $('.arrow-container.right-arrow').css('visibility', 'hidden');
    }
    else {
        $('.arrow-container.right-arrow').css('visibility', 'visible');
    }

    if (scrollLeft === 0) {
        $('.arrow-container.left-arrow').css('visibility', 'hidden');
    }
    else {
        $('.arrow-container.left-arrow').css('visibility', 'visible');
    }
}