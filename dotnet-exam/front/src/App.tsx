import React, {useEffect, useState} from 'react';
import './App.css';
import * as yup from "yup";
import {useFormik} from "formik";
import axios from "axios";
import "./styles.css";


function App() {

    const formik = useFormik({
        initialValues: {
            fullName: "",
            passportSeries: "",
            passportNumber: "",
            passportGiven: "",
            passportGivenDate: "",
            passportRegistration: "",
            age: "",
            criminalRecord: "",
            sum: "",
            goal: "",
            employment: "",
            otherLoans: "",
            pledge: "",
            carAge: 0

        }, validationSchema: yup.object({
            fullName: yup.string().required("Обязательное поле").max(50),
            passportSeries: yup.string().required("Обязательное поле").min(4, "Некорректные данные").max(4, "Некорректные данные"),
            passportNumber: yup.string().required("Обязательное поле").min(6, "Некорректные данные").max(6, "Некорректные данные"),
            passportGiven: yup.string().required("Обязательное поле").min(10, "Слишком коротко").max(40, "Слишком длинно"),
            passportGivenDate: yup.string().required("Обязательное поле. Формат: 2021-10-21"),
            passportRegistration: yup.string().required("Обязательное поле").min(5, "Слишком коротко").max(50, "Слишком длинно"),
            age: yup.number().required("Обязательное поле").min(18, "Вы слишком молоды").max(100, "Вы слишком стары"),
            sum: yup.number().required("Обязательное поле").min(0, "Некорректные данные").max(10000000, "Больше 10 млн. не выдаём"),
            goal: yup.string().required("Обязательное поле").max(50),
            employment: yup.string().required("Обязательное поле").max(50),
            pledge: yup.string().required("Обязательное поле").max(50),
            criminalRecord: yup.string().required("Обязательное поле").max(50),
            otherLoans: yup.string().required("Обязательное поле").max(50),
            carAge: yup.number().min(0).max(50),
        }),
        onSubmit: ({
                       fullName,
                       passportSeries,
                       passportNumber,
                       passportGiven,
                       passportGivenDate,
                       passportRegistration,
                       age,
                       criminalRecord,
                       sum,
                       goal,
                       employment,
                       otherLoans,
                       pledge,
                       carAge
                   }) => {

            const checkCredit = async () => {
                try {
                    const response = await axios.post(
                        "http://localhost:3002/credit/getCredit",
                        {
                            fullName,
                            passportSeries,
                            passportNumber,
                            passportGiven,
                            passportGivenDate,
                            passportRegistration,
                            age,
                            criminalRecord,
                            sum,
                            goal,
                            employment,
                            otherLoans,
                            pledge,
                            carAge
                        }
                    );
                    alert(`Баллы: ${response.data.Score}\n Процентная ставка: ${response.data.creditRate}\n Разрешен ли кредит: ${response.data.Result}\n ${response.data.Message}`)
                } catch (e) {
                    alert(e);
                }
            }
            checkCredit()
        }
    })

    useEffect(() => {
    })

    const hiddenInput = {
        display: 'none',
    };
    const openInput = {
        display: 'block',
    };

    return (
        <div className="modal active">
            <form className="modal_wrapper bg-light" onSubmit={formik.handleSubmit} onReset={formik.handleReset}>
                <div className="heading color-secondary-dark">
                    <h2>Мгновенный кредит</h2>
                </div>

                <div className="horizontal">
                    <input
                        className="input"
                        type="text"
                        placeholder="Ф.И.О."
                        name="fullName"
                        onChange={formik.handleChange}
                        onBlur={formik.handleBlur}
                        value={formik.values.fullName}
                        autoComplete="off"
                    />
                    <div className="validation">
                        <div className="color-danger error">
                            {formik.touched.fullName && formik.errors.fullName ? (
                                formik.errors.fullName
                            ) : null}
                        </div>
                    </div>
                </div>


                <div className="horizontal">
                    <input
                        className="input"
                        type="text"
                        placeholder="Серия паспорта"
                        name="passportSeries"
                        onChange={formik.handleChange}
                        onBlur={formik.handleBlur}
                        value={formik.values.passportSeries}
                        autoComplete="off"
                    />
                    <div className="validation">
                        <div className="color-danger error">
                            {formik.touched.passportSeries && formik.errors.passportSeries ? (
                                formik.errors.passportSeries
                            ) : null}
                        </div>
                    </div>
                    <input
                        className="input"
                        type="text"
                        placeholder="Номер паспорта"
                        name="passportNumber"
                        onChange={formik.handleChange}
                        onBlur={formik.handleBlur}
                        value={formik.values.passportNumber}
                        autoComplete="off"
                    />
                    <div className="validation">
                        <div className="color-danger error">
                            {formik.touched.passportNumber && formik.errors.passportNumber ? (
                                formik.errors.passportNumber
                            ) : null}
                        </div>
                    </div>
                </div>


                <div className="horizontal">
                    <input
                        className="input"
                        type="text"
                        placeholder="Кем выдан"
                        name="passportGiven"
                        onChange={formik.handleChange}
                        onBlur={formik.handleBlur}
                        value={formik.values.passportGiven}
                        autoComplete="off"
                    />
                    <div className="validation">
                        <div className="color-danger error">
                            {formik.touched.passportGiven && formik.errors.passportGiven ? (
                                formik.errors.passportGiven
                            ) : null}
                        </div>
                    </div>


                    <input
                        className="input"
                        type="text"
                        placeholder="Дата выдачи"
                        name="passportGivenDate"
                        onChange={formik.handleChange}
                        onBlur={formik.handleBlur}
                        value={formik.values.passportGivenDate}
                        autoComplete="off"
                    />
                    <div className="validation">
                        <div className="color-danger error">
                            {formik.touched.passportGivenDate && formik.errors.passportGivenDate ? (
                                formik.errors.passportGivenDate
                            ) : null}
                        </div>
                    </div>


                    <input
                        className="input"
                        type="text"
                        placeholder="Информация о прописке"
                        name="passportRegistration"
                        onChange={formik.handleChange}
                        onBlur={formik.handleBlur}
                        value={formik.values.passportRegistration}
                        autoComplete="off"
                    />
                    <div className="validation">
                        <div className="color-danger error">
                            {formik.touched.passportRegistration && formik.errors.passportRegistration ? (
                                formik.errors.passportRegistration
                            ) : null}
                        </div>
                    </div>
                </div>

                <div className="block">
                    <input
                        className="input"
                        type="number"
                        placeholder="Возраст"
                        name="age"
                        onChange={formik.handleChange}
                        onBlur={formik.handleBlur}
                        value={formik.values.age}
                        autoComplete="off"
                    />
                </div>
                <div className="validation">
                    <div className="color-danger error">
                        {formik.touched.age && formik.errors.age ? (
                            formik.errors.age
                        ) : null}
                    </div>
                </div>


                <input
                    className="input"
                    type="number"
                    placeholder="Сумма кредита"
                    name="sum"
                    onChange={formik.handleChange}
                    onBlur={formik.handleBlur}
                    value={formik.values.sum}
                    autoComplete="off"
                />
                <div className="validation">
                    <div className="color-danger error">
                        {formik.touched.sum && formik.errors.sum ? (
                            formik.errors.sum
                        ) : null}
                    </div>
                </div>


                <select
                    className="input"
                    placeholder="Цель"
                    name="goal"
                    onChange={formik.handleChange}
                    onBlur={formik.handleBlur}
                    value={formik.values.goal}
                >
                    <option value="">Выберите цель</option>
                    <option value="Consumer">Потребительский кредит</option>
                    <option value="RealEstate">Недвижимость</option>
                    <option value="OnLending">Перекредитование</option>
                </select>
                <div className="validation">
                    <div className="color-danger error">
                        {formik.touched.goal && formik.errors.goal ? (
                            formik.errors.goal
                        ) : null}
                    </div>
                </div>


                <select
                    className="input"
                    placeholder="Трудоустройство"
                    name="employment"
                    onChange={formik.handleChange}
                    onBlur={formik.handleBlur}
                    value={formik.values.employment}
                >
                    <option value="">Выберите трудоустройство</option>
                    <option value="Unemployed">Безработный</option>
                    <option value="Contract">Трудоустроен по трудовому договору</option>
                    <option value="Individual">Собственное ИП</option>
                    <option value="Freelancer">Фрилансер</option>
                    <option value="Pensioner">Пенсионер</option>
                </select>
                <div className="validation">
                    <div className="color-danger error">
                        {formik.touched.employment && formik.errors.employment ? (
                            formik.errors.employment
                        ) : null}
                    </div>
                </div>

                <div className="horizontal">
                    <select
                        className="input"
                        placeholder=""
                        name="criminalRecord"
                        onChange={formik.handleChange}
                        onBlur={formik.handleBlur}
                        value={formik.values.criminalRecord}
                    >
                        <option value="">Есть судимости?</option>
                        <option value="Yes">Есть</option>
                        <option value="No">Нет</option>
                    </select>
                </div>

                <div className="horizontal">
                    <select
                        className="input"
                        placeholder="Есть действующие кредиты?"
                        name="otherLoans"
                        onChange={formik.handleChange}
                        onBlur={formik.handleBlur}
                        value={formik.values.otherLoans}
                    >
                        <option value="">Есть действующие кредиты?</option>
                        <option value="Yes">Да</option>
                        <option value="No">Нет</option>
                    </select>
                </div>

                <select
                    className="input"
                    placeholder="Залог"
                    name="pledge"
                    onChange={formik.handleChange}
                    onBlur={formik.handleBlur}
                    value={formik.values.pledge}
                >
                    <option value="">Выберите залог</option>
                    <option value="NonPledge">Без залога</option>
                    <option value="RealEstate">Недвижимость</option>
                    <option value="Car">Автомобиль</option>
                    <option value="Guarantee">Поручительство</option>
                </select>

                <input
                    style={formik.values.pledge === "3" ? openInput : hiddenInput}
                    className="input"
                    type="number"
                    placeholder="Возраст авто"
                    name="carAge"
                    required={formik.values.pledge === "Автомобиль"}
                    onChange={formik.handleChange}
                    onBlur={formik.handleBlur}
                    value={formik.values.carAge}
                    autoComplete="off"
                />
                <div className="validation">
                    <div className="color-danger error">
                        {formik.touched.carAge && formik.errors.carAge ? (
                            formik.errors.carAge
                        ) : null}
                    </div>
                </div>
                <div className="validation">
                    <div className="color-danger error">
                        {formik.touched.pledge && formik.errors.pledge ? (
                            formik.errors.pledge
                        ) : null}
                    </div>
                </div>

                <button type="submit" className="button dark color-green" onClick={() => {

                }}> Получить
                </button>

                <button type="reset" className="button dark color-red" onClick={() => {
                    formik.resetForm();
                }}> Очистить
                </button>

            </form>
        </div>
    );
}

export default App;
