-- Dados gerados pelo ChatGPT
INSERT INTO Categorias (nome_categoria) 
VALUES 
('Física'),
('Biologia'),
('Química'),
('Astronomia'),
('Tecnologia');

INSERT INTO FormularioTema (nome, email, tema, id_categoria) 
VALUES 
('Carlos Souza', 'carlos.souza@email.com', 'O impacto da física quântica no cotidiano', 1), 
('Ana Oliveira', 'ana.oliveira@email.com', 'A evolução dos sistemas biológicos no ambiente urbano', 2),
('João Santos', 'joao.santos@email.com', 'Avanços recentes na química ambiental', 3),
('Mariana Lima', 'mariana.lima@email.com', 'A origem e evolução do universo', 4),
('Pedro Almeida', 'pedro.almeida@email.com', 'Inovações tecnológicas na medicina', 5);

INSERT INTO FormularioArtigo (nome, email, titulo, conteudo, id_categoria) 
VALUES 
('Fernanda Silva', 'fernanda.silva@email.com', 'O poder dos aceleradores de partículas', 'Uma discussão sobre o impacto dos aceleradores de partículas em nossa compreensão da física.', 1), 
('Ricardo Pereira', 'ricardo.pereira@email.com', 'A genética no combate a doenças', 'Como os avanços em genética têm contribuído para a cura de doenças complexas.', 2),
('Juliana Costa', 'juliana.costa@email.com', 'Novos materiais para a química sustentável', 'Estudos recentes sobre compostos químicos que podem revolucionar o desenvolvimento sustentável.', 3),
('Lucas Matos', 'lucas.matos@email.com', 'Exploração do sistema solar', 'Uma análise das missões espaciais e os principais desafios da exploração interplanetária.', 4),
('Paula Nunes', 'paula.nunes@email.com', 'Tecnologia de impressão 3D em próteses', 'Como a impressão 3D está revolucionando a criação de próteses mais acessíveis.', 5);

INSERT INTO Artigos (data, titulo, conteudo, nome) 
VALUES 
('2024-01-15T10:00:00', 'A Teoria das Cordas: uma revolução na física', 
'Este artigo explora os fundamentos da Teoria das Cordas, uma proposta revolucionária na física teórica. A teoria sugere que as partículas fundamentais do universo não são pontos, mas sim pequenas cordas vibrantes que oscilam em diferentes modos. Esta visão alternativa tenta unir a mecânica quântica e a relatividade geral, oferecendo uma possível solução para o problema da gravidade quântica. A teoria das cordas também sugere a existência de dimensões adicionais além das conhecidas quatro dimensões do espaço-tempo. Vamos discutir como essa teoria pode resolver problemas antigos e abrir novas possibilidades para a física moderna. A análise abrange desde a origem da teoria até suas implicações para a física de partículas e cosmologia.', 
'Carlos Souza'),

('2024-02-28T14:30:00', 'A vida artificial e seus impactos futuros', 
'A vida artificial representa uma nova fronteira na biologia e na tecnologia. Este artigo examina os avanços recentes na criação de organismos artificiais em laboratório, incluindo a engenharia genética e a síntese de vida a partir de componentes químicos básicos. A vida artificial pode redefinir o conceito de vida e trazer implicações profundas para a biotecnologia, a medicina e a ética. Discutiremos as técnicas atuais usadas para criar vida artificial, os desafios enfrentados, e as possíveis aplicações, como novos métodos de produção de medicamentos e soluções para problemas ambientais. O artigo também considera as implicações éticas de criar e manipular organismos artificiais.', 
'Ana Oliveira'),

('2024-03-10T09:15:00', 'A Química e as Mudanças Climáticas', 
'As mudanças climáticas são um dos maiores desafios enfrentados pela humanidade hoje. Este artigo oferece uma análise detalhada dos compostos químicos envolvidos no processo de aquecimento global, como os gases de efeito estufa, incluindo dióxido de carbono, metano e óxidos de nitrogênio. Exploramos como esses compostos são produzidos, seus efeitos sobre a atmosfera e os impactos resultantes nas condições climáticas globais. Além disso, discutimos estratégias para mitigar as mudanças climáticas através de inovações tecnológicas e políticas ambientais. O artigo fornece uma visão abrangente das interações químicas que impulsionam o aquecimento global e as soluções potenciais para enfrentar este problema.', 
'João Santos'),

('2024-04-20T16:45:00', 'O Telescópio James Webb: a nova era da astronomia', 
'O Telescópio Espacial James Webb é um dos avanços mais significativos na observação astronômica desde o Hubble. Este artigo explora as capacidades do James Webb, incluindo sua habilidade de observar o universo em comprimentos de onda infravermelhos, o que permite visualizar objetos distantes e antigos que não são visíveis com telescópios ópticos. Discutimos como o Webb está ajudando a revelar novas informações sobre a formação das primeiras galáxias, estrelas e sistemas planetários, e como ele pode contribuir para a busca de vida em exoplanetas. O artigo destaca as principais descobertas e expectativas associadas a este telescópio inovador.', 
'Mariana Lima'),

('2024-05-30T11:00:00', 'Nanotecnologia no tratamento do câncer', 
'A nanotecnologia está revolucionando o campo do tratamento do câncer, oferecendo novas abordagens para a detecção e tratamento da doença. Este artigo explora como nanopartículas e outras ferramentas nanotecnológicas estão sendo desenvolvidas para melhorar a precisão dos diagnósticos e a eficácia dos tratamentos. Discutimos como essas tecnologias permitem a entrega direcionada de medicamentos diretamente às células cancerígenas, minimizando os efeitos colaterais e melhorando os resultados terapêuticos. O artigo também examina as atuais pesquisas e desenvolvimentos na área da nanotecnologia aplicada ao câncer, bem como os desafios e as promessas futuras.', 
'Pedro Almeida');

INSERT INTO Artigos (data, titulo, conteudo, nome) 
VALUES 
('2024-02-10T14:30:00', 'A Inteligência Artificial e os Limites da Ética', 
'Com o avanço das tecnologias de inteligência artificial, surgem novas questões sobre os limites éticos da sua aplicação. Este artigo examina como sistemas de IA estão sendo utilizados em decisões que envolvem vidas humanas, como na área da saúde e justiça, e discute os desafios de garantir que essas máquinas operem com princípios éticos e transparência. A análise também explora as responsabilidades de programadores e cientistas em projetar IA segura e justa para a sociedade.', 
'Fernanda Ribeiro'),

('2024-03-18T09:15:00', 'Exploração Espacial: As Missões a Marte e Seus Desafios', 
'O interesse em explorar Marte continua a crescer, com agências espaciais e empresas privadas competindo para enviar humanos ao Planeta Vermelho. Este artigo explora os principais desafios dessas missões, desde as questões tecnológicas, como a criação de habitats sustentáveis, até os desafios biológicos, como o impacto da radiação espacial em astronautas. A análise inclui os avanços mais recentes nas missões da NASA e da SpaceX, bem como o impacto potencial dessas viagens na exploração futura do sistema solar.', 
'Rafael Martins'),

('2024-04-25T17:45:00', 'Energia Sustentável: O Futuro da Energia Solar e Eólica', 
'O mundo enfrenta uma crescente demanda por fontes de energia sustentáveis, e as energias solar e eólica têm ganhado destaque como alternativas promissoras. Este artigo examina o estado atual dessas tecnologias, os avanços recentes em armazenamento de energia e as políticas que estão impulsionando seu crescimento. A análise inclui uma discussão sobre como a transição para essas fontes limpas pode mitigar os impactos das mudanças climáticas e melhorar a segurança energética global.', 
'Letícia Andrade');

INSERT INTO Artigos (data, titulo, conteudo, nome) 
VALUES 
('2024-09-11T10:30:00', 'Avanços na Inteligência Artificial Transformam a Medicina',
'No dia de hoje, pesquisadores anunciaram um avanço revolucionário no uso de inteligência artificial (IA) na medicina. A nova tecnologia é capaz de diagnosticar doenças raras em questão de segundos, utilizando grandes volumes de dados clínicos e históricos de pacientes. Esta IA pode analisar imagens de exames com precisão superior a de especialistas humanos, oferecendo diagnósticos e recomendações personalizadas. O impacto dessa inovação é promissor, abrindo caminho para uma medicina mais rápida e precisa, principalmente em regiões com poucos médicos especialistas. Este avanço pode redefinir o futuro dos cuidados de saúde.',
'Mariana Oliveira');
