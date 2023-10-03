export class Produto {
    id?: number;
    codigo?: number;
    descricao?: string;
    marca?: string;
    valor?: number;
    estoque?: number

    constructor(id ?: number,codigo ?: number, descricao ?: string, marca ?: string, valor ?: number, estoque ?: number) {
       this.id = id;
       this.codigo = codigo;
       this.descricao = descricao;
       this.marca = marca;
       this.valor = valor;
       this.estoque = estoque;
    }
}
