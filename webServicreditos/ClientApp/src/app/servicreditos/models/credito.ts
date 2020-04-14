export class Credito {
    identificacion: string;
    nombre: string;
    capitalInicial: number;
    tasaInteres: number;
    tiempoDuracion: number;

    calcularTasaInteres(){
        return this.tasaInteres / 100;
    }

    calcularTotalPagar(){
        if(this.capitalInicial > 0 && this.tiempoDuracion > 0){
            return this.capitalInicial * (Math.pow(1 + this.calcularTasaInteres(), this.tiempoDuracion));
        }
        return 0;
    }
}
