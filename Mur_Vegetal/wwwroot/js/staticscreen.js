var elements = [];
var displayTimer = 1000;
var a = document.getElementById("a");
var b = document.getElementById("b");
var c = document.getElementById("c");
var d = document.getElementById("d");
var e = document.getElementById("e");
a.style.display = "none";
b.style.display = "none";
c.style.display = "none";
d.style.display = "none";
e.style.display = "none";
elements.push(a, b, c, d, e);

async function defile() {

  for (let i = 0; i < elements.length; i++) {
    if (i - 1 < 0) {
      elements[elements.length - 1].style.display = 'none';
    } else {
      elements[i - 1].style.display = 'none';
    }
    elements[i].style.display = 'block';
    await wait1Second();

  }
 
}

function wait1Second(x) {
  return new Promise(resolve => {
    setTimeout(() => {
      resolve(x);
    }, displayTimer);
  });
}

setInterval(() => {
  defile();
}, elements.length*displayTimer);

