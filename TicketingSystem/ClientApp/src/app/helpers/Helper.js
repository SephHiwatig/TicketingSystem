"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var http_1 = require("@angular/common/http");
var Helper = /** @class */ (function () {
    function Helper() {
    }
    Helper.getHeaders = function () {
        var headers = new http_1.HttpHeaders();
        headers = headers.set('Content-Type', 'application/json');
        var token = localStorage.getItem('token');
        if (!token || token === '') {
            return headers;
        }
        var tokenValue = 'Bearer ' + token;
        headers = headers.set('Authorization', tokenValue);
        return headers;
    };
    return Helper;
}());
exports.Helper = Helper;
//# sourceMappingURL=Helper.js.map