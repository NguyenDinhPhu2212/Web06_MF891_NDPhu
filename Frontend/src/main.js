import Vue from "vue";
import VTooltip from "v-tooltip";

import Employee from "./views/employee/Employee.vue";
import BaseInput from "./components/base/BaseInput.vue";
import Loading from "./components/base/Loading.vue";
import BaseCombobox from "./components/base/Combobox.vue";
import CustomCheckBox from "./components/base/CheckBox.vue";
import CustomRadio from "./components/base/Radio.vue";
import ToastGroup from "./components/base/toast/ToastGroup.vue";
import Popup from "./components/base/Popup.vue";
import CustomDropdown from "./components/base/Dropdown.vue";
import NoContent from "./components/base/NoContent.vue";
import { store } from "./store/store";
import router from "./router";
Vue.config.productionTip = false;

Vue.component("CustomRadio", CustomRadio);
Vue.component("CustomCheckBox", CustomCheckBox);
Vue.component("BaseInput", BaseInput);
Vue.component("BaseCombobox", BaseCombobox);
Vue.component("Loading", Loading);
Vue.component("ToastGroup", ToastGroup);
Vue.component("Popup", Popup);
Vue.component("CustomDropdown", CustomDropdown);
Vue.component("NoContent", NoContent);
Vue.use(VTooltip);
new Vue({
    router,
    store: store,
    render: (h) => h(Employee),
}).$mount("#app");
