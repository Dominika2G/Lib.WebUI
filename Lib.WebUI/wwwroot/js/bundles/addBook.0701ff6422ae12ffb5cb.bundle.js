/*
 * ATTENTION: The "eval" devtool has been used (maybe by default in mode: "development").
 * This devtool is neither made for production nor for readable output files.
 * It uses "eval()" calls to create a separate source file in the browser devtools.
 * If you are trying to read the output file, select a different devtool (https://webpack.js.org/configuration/devtool/)
 * or disable the default devtool with "devtool: false".
 * If you are looking for production-ready output files, see mode: "production" (https://webpack.js.org/configuration/mode/).
 */
/******/ (() => { // webpackBootstrap
/******/ 	var __webpack_modules__ = ({

/***/ "./Features/Book/Content/AddBook/addBook.js":
/*!**************************************************!*\
  !*** ./Features/Book/Content/AddBook/addBook.js ***!
  \**************************************************/
/***/ (() => {

eval("window.addBook = (() => {\n  const init = () => {};\n\n  const generateCode = () => {\n    let r = Math.floor(Math.random() * 1000000000 + 1);\n    $(\"#barCode\").val(r);\n  };\n\n  return {\n    init,\n    generateCode\n  };\n})();\n\n$(function () {\n  addBook.init();\n});\n\n//# sourceURL=webpack://lib.webui/./Features/Book/Content/AddBook/addBook.js?");

/***/ })

/******/ 	});
/************************************************************************/
/******/ 	
/******/ 	// startup
/******/ 	// Load entry module and return exports
/******/ 	// This entry module can't be inlined because the eval devtool is used.
/******/ 	var __webpack_exports__ = {};
/******/ 	__webpack_modules__["./Features/Book/Content/AddBook/addBook.js"]();
/******/ 	
/******/ })()
;