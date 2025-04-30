import { Shape } from './shape';

export class UserSettings {
    constructor(
        public gender: boolean,  // true for women, false for men
        public style: string,
        public shape: Shape,
    ) { }
}