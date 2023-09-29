export class Usuario {
    id: number = 0;
    name: string = "";
    email: string = "";
    senha: string = "";
    uf: string ="";
    telefone: string ="";

    constructor(id: number,name: string, email: string,senha: string,uf:string,telefone:string){

        this.id = id;
        this.name = name;
        this.email = email;
        this.senha = senha;
        this.uf = uf;
        this.telefone = telefone;
       
    }
 
}
