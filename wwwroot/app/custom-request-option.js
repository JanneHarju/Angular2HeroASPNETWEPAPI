"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
const core_1 = require('@angular/core');
const http_1 = require('@angular/http');
let CustomRequestOptions_1 = class CustomRequestOptions extends http_1.RequestOptions {
    merge(options) {
        if (options !== null && options.url !== null) {
            options.url = 'http://localhost:3000' + options.url;
        }
        let requestOptions = super.merge(options);
        return new CustomRequestOptions_1({
            method: requestOptions.method,
            url: requestOptions.url,
            search: requestOptions.search,
            headers: requestOptions.headers,
            body: requestOptions.body,
            withCredentials: requestOptions.withCredentials,
            responseType: requestOptions.responseType
        });
    }
};
let CustomRequestOptions = CustomRequestOptions_1;
CustomRequestOptions = CustomRequestOptions_1 = __decorate([
    core_1.Injectable(), 
    __metadata('design:paramtypes', [])
], CustomRequestOptions);
exports.CustomRequestOptions = CustomRequestOptions;
//# sourceMappingURL=custom-request-option.js.map