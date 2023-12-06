using Microsoft.AspNetCore.Mvc;

namespace EasyGamesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientData _clientData;
        public ClientController(IClientData clientData)
        {
            _clientData = clientData ?? throw new ArgumentNullException(nameof(clientData));
        }

        [HttpGet]
        [Route("GetClients")]
        public async Task<IActionResult> GetClients() {
            try
            {
                var clients = await _clientData.GetAllClients();
                return Ok(clients);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetClientById/{id}")]
        public async Task<IActionResult> GetClientById(int id)
        {
            try
            {
                var client = await _clientData.GetClientById(id);
                return Ok(client);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("InsertClient")]
        public async Task<IActionResult> InsertClient(Client client)
        {
            try
            {
                await _clientData.InsertClient(client);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteClient/{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            try
            {
                await _clientData.DeleteClient(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetAllTransactionTypes")]
        public async Task<IActionResult> GetAllTransactionTypes()
        {
            try
            {
                var transactionTypes = await _clientData.GetAllTransactionTypes();
                return Ok(transactionTypes);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetTransactionsByClient/{id}")]
        public async Task<IActionResult> GetTransactionsByClient(int id)
        {
            try
            {
                var transactions = await _clientData.GetTransactionsByClient(id);
                return Ok(transactions);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("InsertTransaction")]
        public async Task<IActionResult> InsertTransaction(Transactions transactions)
        {
            try
            {
                await _clientData.InsertTransaction(transactions);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateTransactionComment")]
        public async Task<IActionResult> UpdateTransactionComment(Transactions transactions)
        {
            try
            {
                await _clientData.UpdateTransactionComment(transactions);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
