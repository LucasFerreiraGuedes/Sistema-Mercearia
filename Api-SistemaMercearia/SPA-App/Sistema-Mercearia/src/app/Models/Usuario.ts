export class Usuario {
    Id: number;
    Nome: string;
    Email: string;
    Senha: string;
    Uf: string;
    Telefone: string;

    constructor(id: number,nome: string, email: string,senha: string,uf:string,telefone:string){

        this.Id = id;
        this.Nome = nome;
        this.Email = email;
        this.Senha = senha;
        this.Uf = uf;
        this.Telefone = telefone;
       
    }

}
