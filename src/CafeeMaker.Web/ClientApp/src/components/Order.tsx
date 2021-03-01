import React, {useState, useEffect, ChangeEvent} from "react";
import {DrinkIngredient, getDrinkIngredients, Mug} from "../services/drinkService";
import {useParams} from "react-router";
import {postOrder} from "../services/orderService";
import classNames from "classnames";

import "./Ingredient.scss";

const editableIngredients = ["Sucre"];

export const IngredientList = () => {
    const {drinkId} = useParams();
    const [ingredients, setIngredients] = useState<DrinkIngredient[]>([]);
    const [isLoading, setIsLoading] = useState(true);
    const [sugarValue, setSugarValue] = useState();
    const [mugValue, setMugValue] = useState(Mug.small);

    useEffect(() => {
        (async () => {
            setIngredients(await getDrinkIngredients(drinkId));
            setIsLoading(false);
        })();
    }, []);

    function onSugarChange(e: ChangeEvent<HTMLInputElement>) {
        if (e.target.value.length > 3) return;
        setSugarValue(e.target.value);
    }

    const onMugClick = (e: ChangeEvent<HTMLInputElement>) => {
        setMugValue(parseInt(e.target.value, 10) as Mug);
    }

    const onStartClick = async () => {
        const amounts = ingredients.map(i => ({ 
            drinkIngredientId: i.drinkIngredientId, 
            amount: i.ingredient.name === 'Sugar' ? sugarValue : i.amount 
        }));
        
        await postOrder({
            drinkId,
            amounts,
            mug: mugValue
        });
    }

    return (
        <div className="h-100 d-flex justify-content-center align-items-center">
            <div className="card w-75 mb-5">
                {isLoading ? <p>Loading</p> :
                    <div className="card-body">
                        <h2>Ingrédients</h2>
                        <div>Input value: {mugValue}</div>
                        <hr/>
                        <form>
                            {
                                ingredients.map((ingredient) => (
                                    <div className="form-group row" key={ingredient.drinkIngredientId}>
                                        <label
                                            className="col-sm-2 col-form-label font-weight-bold">{ingredient.ingredient.name}</label>
                                        <div className="col-sm-10">
                                            {editableIngredients.indexOf(ingredient.ingredient.name) !== -1
                                                ? <input className="form-control"
                                                         type="number"
                                                         value={sugarValue ?? ingredient.amount}
                                                         onChange={onSugarChange}
                                                         required/>
                                                : <span
                                                    className="font-italic"> ({ingredient.amount.toString()} mls)</span>
                                            }
                                        </div>
                                    </div>
                                ))
                            }
                            <div className="form-group row">
                                <label className="col-sm-2 col-form-label font-weight-bold">Taille</label>
                                <div className="col-sm-10">
                                    <div className="button-group-control btn-group btn-group-toggle"
                                         data-toggle="buttons">
                                        <label className={classNames("btn", "btn-secondary", { "active": mugValue == Mug.small })}>
                                            <input type="radio" name="options" value={Mug.small} id="option1"
                                                   onChange={onMugClick}
                                            /> Petite
                                        </label>
                                        <label className={classNames("btn", "btn-secondary", { "active": mugValue == Mug.medium })}>
                                            <input type="radio" name="options" value={Mug.medium} onChange={onMugClick}
                                                   id="option2"/> Moyenne
                                        </label>
                                        <label className={classNames("btn", "btn-secondary", { "active": mugValue == Mug.large })}>
                                            <input type="radio" name="options" value={Mug.large} onChange={onMugClick}
                                                   id="option3"/> Grande
                                        </label>
                                    </div>
                                </div>
                            </div>
                        </form>
                        <hr/>
                        <button className="btn btn-success btn-block"
                                onClick={onStartClick}>
                            Start
                        </button>
                    </div>
                }
            </div>
        </div>
    );
}
