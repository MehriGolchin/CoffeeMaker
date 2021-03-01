import {get} from "./HttpClient"
import {API_BASE_URI} from "../constants";

export interface Drink {
    readonly drinkId: number;
    readonly name: string;
    readonly  image: string;
}

export interface Ingredient {
    readonly ingredientId: number;
    readonly name: string;
}

export interface DrinkIngredient {
    readonly drinkIngredientId: number;
    readonly drinkId: number;
    readonly ingredientId: number;
    readonly amount: number;
    readonly ingredient: Ingredient;
}

export enum Mug {
    small = 1,
    medium = 2,
    large = 3
}

export async function getDrinks() {
    const url = new URL('drink', API_BASE_URI);
    return await get<Drink[]>(url);
}

export async function getDrinkIngredients(id: number){
    const url = new URL(`drink/${id}`, API_BASE_URI);
    return await get<DrinkIngredient[]>(url);
}


