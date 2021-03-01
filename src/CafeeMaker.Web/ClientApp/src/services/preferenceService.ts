import {API_BASE_URI} from "../constants";
import {get} from "./HttpClient";
import {Mug} from "./drinkService";

export interface Preference {
    readonly employeeId: number;
    readonly drinkId: number;
    readonly amounts: { drinkIngredientId: number, amount: number }[];
    readonly mug: Mug;
}

export async function getPreference(drinkId: number){
    const url = new URL(`preference/${drinkId}`, API_BASE_URI);
    return await get<Preference>(url);
}