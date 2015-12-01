using MovieNight.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using MovieNight.Domain.Entities;

namespace MovieNight.WebAPI.Controllers
{
    [RoutePrefix("api/movies")]
    public class MoviesController : ApiController
    {
        private readonly IMoviesRepository _repository;

        public MoviesController(IMoviesRepository repository)
        {
            _repository = repository;
        }

        #region Routes: movies
        [Route("")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetMovies()
        {
            HttpResponseMessage response;

            try
            {
                var results = await _repository.FindAllMovies();

                response = (results == null || results.Count == 0) 
                    ? Request.CreateErrorResponse(HttpStatusCode.NotFound, "No movies found") 
                    : Request.CreateResponse(HttpStatusCode.OK, results);
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }

        [Route("")]
        [HttpPost]
        public async Task<HttpResponseMessage> PostMovie(Movie movie)
        {
            HttpResponseMessage response;

            try
            {
                var results = await _repository.InsertMovie(movie);

                response = Request.CreateResponse(HttpStatusCode.Created, results);
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }
        #endregion

        #region Routes: movies/{movieId}
        [Route("{movieId}")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetMovie(int movieId)
        {
            HttpResponseMessage response;

            try
            {
                var results = await _repository.FindMovieById(movieId);

                response = results == null
                    ? Request.CreateErrorResponse(HttpStatusCode.NotFound, "Movie not found")
                    : Request.CreateResponse(HttpStatusCode.OK, results);
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }

        [Route("{movieId}")]
        [HttpPatch]
        public async Task<HttpResponseMessage> PatchMovie(int movieId, Movie movie)
        {
            HttpResponseMessage response;

            try
            {
                var results = await _repository.UpdateMovie(movieId, movie);

                response = results == null
                    ? Request.CreateErrorResponse(HttpStatusCode.NotFound, "Movie not found")
                    : Request.CreateResponse(HttpStatusCode.Created, results);
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }

        [Route("{movieId}")]
        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteMovie(int movieId)
        {
            HttpResponseMessage response;

            try
            {
                var results = await _repository.DeleteMovie(movieId);

                response = results == null
                    ? Request.CreateErrorResponse(HttpStatusCode.NotFound, "Movie not found")
                    : Request.CreateResponse(HttpStatusCode.OK, results);
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }
        #endregion

        #region Routes: movies/{movieId}/directors
        [Route("{movieId}/directors")]
        [HttpPost]
        public async Task<HttpResponseMessage> PostDirector(int movieId, Director director)
        {
            HttpResponseMessage response;

            try
            {
                var results = await _repository.InsertDirector(movieId, director);

                response = results == null
                    ? Request.CreateErrorResponse(HttpStatusCode.NotFound, "Movie not found")
                    : Request.CreateResponse(HttpStatusCode.Created, results);
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }
        #endregion

        #region Routes: movies/{movieId}/directors/{directorId}
        [Route("{movieId}/directors/{directorId}")]
        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteDirector(int movieId, int directorId)
        {
            HttpResponseMessage response;

            try
            {
                var results = await _repository.DeleteDirector(movieId, directorId);

                response = results == null
                    ? Request.CreateErrorResponse(HttpStatusCode.NotFound, "Movie or director not found")
                    : Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }
        #endregion

        #region Routes: movies/{movieId}/writers
        [Route("{movieId}/writers")]
        [HttpPost]
        public async Task<HttpResponseMessage> PostWriter(int movieId, Writer writer)
        {
            HttpResponseMessage response;

            try
            {
                var results = await _repository.InsertWriter(movieId, writer);

                response = results == null
                    ? Request.CreateErrorResponse(HttpStatusCode.NotFound, "Movie not found")
                    : Request.CreateResponse(HttpStatusCode.Created, results);
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }
        #endregion

        #region Routes: movies/{movieId}/writers/{writerId}
        [Route("{movieId}/writers/{writerId}")]
        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteWriter(int movieId, int writerId)
        {
            HttpResponseMessage response;

            try
            {
                var results = await _repository.DeleteWriter(movieId, writerId);

                response = results == null
                    ? Request.CreateErrorResponse(HttpStatusCode.NotFound, "Movie or writer not found")
                    : Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }
        #endregion

        #region Routes: movies/{movieId}/cast
        [Route("{movieId}/cast")]
        [HttpPost]
        public async Task<HttpResponseMessage> PostCastMember(int movieId, CastMember castMember)
        {
            HttpResponseMessage response;

            try
            {
                var results = await _repository.InsertCastMember(movieId, castMember);

                response = results == null
                    ? Request.CreateErrorResponse(HttpStatusCode.NotFound, "Movie not found")
                    : Request.CreateResponse(HttpStatusCode.Created, results);
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }
        #endregion

        #region Routes: movies/{movieId}/cast/{castMemberId}
        [Route("{movieId}/cast/{castMemberId}")]
        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteCastMember(int movieId, int castMemberId)
        {
            HttpResponseMessage response;

            try
            {
                var results = await _repository.DeleteCastMember(movieId, castMemberId);

                response = results == null
                    ? Request.CreateErrorResponse(HttpStatusCode.NotFound, "Movie or cast member not found")
                    : Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }
        #endregion
    }
}