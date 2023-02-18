use web_sys::HtmlInputElement;
use yew::prelude::*;

#[function_component(App)]
fn app() -> Html {
    let text1 = use_state(|| String::from("ушёл"));
    let text2 = use_state(|| String::from("ушёл"));
    let input = use_node_ref();
    let ome1 = {
        let text1 = text1.clone();
        move |_event| {text1.set("пришёл".into());}
    };
    let oml1 = {
        let text1 = text1.clone();
        move |_event| {text1.set("ушёл".into());}
    };
    let omc1 = {
        let input = input.clone();
        Callback::from(move |_| {
            let inp_handle = input.cast::<HtmlInputElement>().unwrap();
            let inp_string = inp_handle.value();
            if let Ok(mut n) = inp_string.trim().parse::<i32>() {
                n /= 2;
                inp_handle.set_value(&format!("{}",n));
            } else {
                inp_handle.set_value("плохая строка!");
            }
        })
    };
    let ome2 = {
        let text2 = text2.clone();
        move |_event| {text2.set("пришёл".into());}
    };
    let oml2 = {
        let text2 = text2.clone();
        move |_event| {text2.set("ушёл".into());}
    };
    let omc2 = {
        let input = input.clone();
        Callback::from(move |_| {
            let inp_handle = input.cast::<HtmlInputElement>().unwrap();
            let inp_string = inp_handle.value();
            if let Ok(mut n) = inp_string.trim().parse::<i32>() {
                n *= 2;
                inp_handle.set_value(&format!("{}",n));
            } else {
                inp_handle.set_value("плохая строка!");
            }
        })
    };
    html! {
        <main>
        <div>
            <span>
            <button onmouseenter = {ome1} onmouseleave = {oml1} onclick = {omc1}>{&*text1}</button>
            </span>
            <span>
            <button onmouseenter = {ome2} onmouseleave = {oml2} onclick = {omc2}>{&*text2}</button>
            </span>
        </div>
        <input type="text" ref={input} />
        </main>
    }
}

fn main() {
    yew::Renderer::<App>::new().render();
}
