import { Article } from "./article";

export class Outfit {
    constructor(
        public top: Article,
        public bottom: Article,
        public shoes: Article,
        public accessory: Article) { }
}