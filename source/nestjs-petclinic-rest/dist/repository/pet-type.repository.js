"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.PetTypeRepository = void 0;
const typeorm_1 = require("typeorm");
const typeorm_ex_decorator_1 = require("./../typeorm/typeorm-ex.decorator");
const pet_type_entity_1 = require("./../domain/entities/pet-type.entity");
const intent_decorators_1 = require("./../intent/intent.decorators");
let PetTypeRepository = class PetTypeRepository extends typeorm_1.Repository {
};
PetTypeRepository = __decorate([
    (0, intent_decorators_1.IntentMerge)(),
    (0, typeorm_ex_decorator_1.CustomRepository)(pet_type_entity_1.PetType)
], PetTypeRepository);
exports.PetTypeRepository = PetTypeRepository;
//# sourceMappingURL=pet-type.repository.js.map