
<h1 align="center"><img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/csharp/csharp-original.svg" alt="csharp" width="40" height="40"/> Projetos BackEnd</h1>  
<h3 align="center">do básico ao avançado</h3>   
Alguns dos meus projetos mais bacanas CSharp

> <ol>
> <li>Sorteador de números da loteria</li>
> <li>Controle de gastos pessoais</li>
</ol>

<h3>Sorteador de números da loteria</h3>

> <h6><a href="https://github.com/pedrodk1990/CSharp/tree/main/AppLoteria">Projeto</a></h6>
> <h6><a href="https://github.com/pedrodk1990/CSharp/tree/main/AppLoteria/AppLoteria/Program.cs">Código</a></h6>

<p>Gera 6 números entre 1 e 60 aleatóriamente sem repetição.</p>

<code>

	namespace AppLoteria
	{
	    class Program
	    {
	        static void Main(string[] args)
	        {
	            int[] numeros = new int[6]; //Vetor para armazenar os números gerados.
	            var rdm = new Random(); //Cria uma variável do tipo Random.
	            int aleatorio; //Cria uma variável para comparação com o valor do próximo número gerado.
	            
	            //Estrutura de repetição para gerar os números de acordo com o tamanho do vetor.
	            for(var i = 0; i < numeros.Length; i++)
	            {
	               aleatorio = rdm.Next(1,61); //Gera um número entre 1 e 60.
	                while (numeros.Contains(aleatorio)) //Estrutura de repetição para comparar o número gerado com os números armazenados no vetor
	                {
	                    aleatorio = rdm.Next(1, 61); //Um novo número randomico é atribuido apenas quando ele não existir no vetor
	                }
	                    numeros[i] = aleatorio; //Atribui o número gerado ao vetor
	                Console.Write(numeros[i].ToString() + " "); //Escreve na tela
	            }
	        }
	    }
	}
</code>



<h3>Controle de gastos pessoais</h3>

> <h6><a href="https://github.com/pedrodk1990/CSharp/tree/main/GastosPessoais">Projeto</a></h6>
> <h6><a href="https://github.com/pedrodk1990/CSharp/tree/main/GastosPessoais/GastosPessoais/Program.cs">Código</a></h6>

<p>Adiciona, Edita, Remove e Lista atividades econômicas pessoais, calculando despesas e receitas, baseado em windows forms. Conta com um relatório básico criado com ReportViewer.</p>


