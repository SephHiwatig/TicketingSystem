"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var rxjs_1 = require("rxjs");
var operators_1 = require("rxjs/operators");
var TicketResolver = /** @class */ (function () {
    function TicketResolver(ticketService, router) {
        this.ticketService = ticketService;
        this.router = router;
    }
    TicketResolver.prototype.resolve = function (route) {
        var _this = this;
        var ticketId = route.params['id'];
        return this.ticketService.getTicketInfo(ticketId).pipe(operators_1.catchError(function () {
            _this.router.navigate(['']);
            return rxjs_1.of(null);
        }));
    };
    return TicketResolver;
}());
exports.TicketResolver = TicketResolver;
//# sourceMappingURL=ticket.resolver.js.map