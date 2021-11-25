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

/***/ "./Features/Shared/Content/core/core.js":
/*!**********************************************!*\
  !*** ./Features/Shared/Content/core/core.js ***!
  \**********************************************/
/***/ (() => {

eval("window.extensionCore = (() => {\n  const init = () => {\n    removeConstScript();\n    removePartialScript();\n  };\n\n  const removeConstScript = () => {\n    $(\"#ConstScriptElements\").remove();\n    $(\"#SharedConstScriptElements\").remove();\n  };\n\n  const removePartialScript = () => {\n    $(\".emuze-partial-script-elements\").remove();\n  };\n\n  const getHash = str => {\n    let hash = 0,\n        i = 0,\n        len = str.length;\n\n    while (i < len) {\n      hash = (hash << 5) - hash + str.charCodeAt(i++) << 0;\n    }\n\n    return hash;\n  };\n\n  return {\n    init,\n    removePartialScript,\n    contentFullSpace,\n    getHash\n  };\n})();\n\n$(function () {\n  extensionCore.init();\n});\n\n//# sourceURL=webpack://lib.webui/./Features/Shared/Content/core/core.js?");

/***/ })

/******/ 	});
/************************************************************************/
/******/ 	
/******/ 	// startup
/******/ 	// Load entry module and return exports
/******/ 	// This entry module can't be inlined because the eval devtool is used.
/******/ 	var __webpack_exports__ = {};
/******/ 	__webpack_modules__["./Features/Shared/Content/core/core.js"]();
/******/ 	
/******/ })()
;