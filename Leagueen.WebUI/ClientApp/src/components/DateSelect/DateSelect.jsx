import React from "react";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker-cssmodules.css";
import "./DateSelect.scss";

function DateSelect(props) {

    function getClassName() {
        return "custom-datepicker";
    }

    function getCalendarClassName() {
        if(props.withPortal)
            return "custom-calendar-datepicker__portal"
        return "custom-calendar-datepicker"
    }

    return (
        <>
            <DatePicker
                className={getClassName()}
                calendarClassName={getCalendarClassName()}
                dateFormat="dd/MM/yyyy"
                selected={props.date}
                onChange={props.onChange} 
                onClickOutside={props.close}
                {...props}/>
        </>
    );
};

export { DateSelect };