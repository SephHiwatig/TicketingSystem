"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var router_1 = require("@angular/router");
var home_component_1 = require("./home/home.component");
var routes = [
    { path: '', component: home_component_1.HomeComponent, pathMatch: 'full' }
];
core_1.NgModule({
    imports: [router_1.RouterModule.forRoot(routes)],
    exports: [router_1.RouterModule]
});
var AppRoutingModule = /** @class */ (function () {
    function AppRoutingModule() {
    }
    return AppRoutingModule;
}());
exports.AppRoutingModule = AppRoutingModule;
//# sourceMappingURL=app-routing.module.js.map